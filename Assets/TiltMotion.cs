using UnityEngine;
using System.Collections;

public class TiltMotion : MonoBehaviour {

    Quaternion startRotation;
    Vector3 oldVelocity = Vector3.zero;
    Rigidbody rigid;

	// Use this for initialization
	void Start () {
        startRotation = transform.rotation;
        rigid = GetComponentInParent<Rigidbody>();
	}
	
	// Update is called once per frame
	void FixedUpdate () {
        if (rigid.velocity.sqrMagnitude > rigid.sleepThreshold)
        {
            float value = Mathf.Min(10, rigid.velocity.sqrMagnitude);
            Vector3 tiltAxis = Vector3.Cross(Vector3.up, transform.forward);
            Quaternion rotateWithTilt = Quaternion.AngleAxis(value, Vector3.right);
            transform.localRotation = Quaternion.RotateTowards(transform.localRotation, rotateWithTilt, 1);
        }
        else
        {
            transform.localRotation = Quaternion.RotateTowards(transform.localRotation, startRotation, 1);
        }
	}
}
