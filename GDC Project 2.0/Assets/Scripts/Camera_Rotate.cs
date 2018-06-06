using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Camera_Rotate : MonoBehaviour {

	public GameObject target;
	public float speed = 10.0F;
	//DO NOT USE LATEUPDATE
	void FixedUpdate(){
		if (transform.rotation.y + 0.5F > target.transform.rotation.y) {
			transform.RotateAround (target.transform.position, -1*Vector3.up, speed * Time.deltaTime);
		}else if(transform.rotation.y - 0.5F < target.transform.rotation.y){
			transform.RotateAround (target.transform.position, Vector3.up, speed * Time.deltaTime);
		}
	}
}
