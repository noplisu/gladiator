using UnityEngine;
using System.Collections;

public class CameraMovement : MonoBehaviour {

    public Transform target;

	void Start () {
	
	}
	
	void Update () {
        transform.position = target.position;
	}
}
