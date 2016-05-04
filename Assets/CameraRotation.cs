using UnityEngine;
using System.Collections;

public class CameraRotation : MonoBehaviour {

	void Start () {
	
	}
	
	void Update () {
        transform.rotation *= Quaternion.Euler(Input.GetAxis("Mouse Y"), Input.GetAxis("Mouse X"), 0);
	}
}
