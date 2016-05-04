using UnityEngine;
using System.Collections;

public class Slash : MonoBehaviour {
    Movement move;
    GameObject hit;
    Rigidbody rigid;

    void Start()
    {
        move = this.GetComponentInParent<Movement>();
        rigid = this.GetComponentInParent<Rigidbody>();
    }

    void FixedUpdate()
    {
        if(!move.attacking)
        {
            hit = null;
        }
    }

    void OnTriggerEnter(Collider other)
    {
        if(move.attacking)
        {
            if (!hit)
            {
                hit = other.gameObject;
                Rigidbody otherRigid = other.GetComponentInParent<Rigidbody>();
                otherRigid.AddForce(move.transform.forward * 500);
            }
        }
    }
}
