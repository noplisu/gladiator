using UnityEngine;
using System.Collections;

public class Movement : MonoBehaviour {

    public float speed = 10;
    public Transform forwardTransform;
    Animator anim;
    public bool attacking = false;

    new Rigidbody rigidbody;

	void Start () {
        rigidbody = GetComponent<Rigidbody>();
        anim = GetComponentInChildren<Animator>();
        SlashStart slash = anim.GetBehaviour<SlashStart>();
        slash.move = this;
	}
	
	void FixedUpdate () {
        //movement
        Vector3 forward = forwardTransform.forward;
        forward.y = 0;
        Vector3 movementVector = forward * Input.GetAxis("Vertical") + forwardTransform.right * Input.GetAxis("Horizontal");
        rigidbody.AddForce(movementVector.normalized * speed);

        //rotation
        if (rigidbody.velocity.sqrMagnitude >= rigidbody.sleepThreshold)
        {
            rigidbody.MoveRotation(Quaternion.LookRotation(rigidbody.velocity));
        }


        //print(rigidbody.velocity.sqrMagnitude);

        //animate
        anim.SetBool("crouch", Input.GetAxisRaw("Crouch") == 1);
        anim.SetFloat("speed", rigidbody.velocity.sqrMagnitude * 5);
        anim.SetBool("defend", Input.GetAxisRaw("Fire2") == 1);
        anim.SetBool("attack", Input.GetAxisRaw("Fire1") == 1);
	}
}
