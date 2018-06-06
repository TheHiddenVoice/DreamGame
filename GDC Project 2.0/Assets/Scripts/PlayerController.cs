using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityStandardAssets.CrossPlatformInput;

public class PlayerController : MonoBehaviour {

	float speed;
	public float jumpSpeed = 8.0F;
	public float rotSpeed = 10.0F;
	public float gravity = 20.0F;
	Stats stats;
	private Vector3 moveDirection = Vector3.zero;
	CharacterController chara;
	void Start(){
		stats = gameObject.GetComponent<Stats>();
		chara = gameObject.GetComponent<CharacterController>();
	}

	// Update is called once per frame
	void FixedUpdate () {
		//transform.localEulerAngles = new Vector3(transform.localEulerAngles.x, Camera.main.transform.localEulerAngles.y, transform.localEulerAngles.z); 
		//transform.Rotate(0,Input.GetAxis("Horizontal")*60F*Time.deltaTime,0);
		speed = stats.SPD * 0.5F;
		float mouse = CrossPlatformInputManager.GetAxis ("Mouse X");
		float horizontal = Input.GetAxis ("Horizontal");
		float vertical = Input.GetAxis ("Vertical");
		transform.Rotate (0, mouse, 0);
		if (chara.isGrounded) {
			float x = horizontal * speed;
			if (horizontal < 0) {
				moveDirection = (transform.TransformDirection (Vector3.left) * speed) + (transform.TransformDirection (Vector3.forward) * speed * vertical);
			} else if (horizontal > 0) {
				moveDirection = (transform.TransformDirection (Vector3.right) * speed) + (transform.TransformDirection (Vector3.forward) * speed * vertical);
			} else {
				moveDirection = transform.TransformDirection (Vector3.forward) * speed * vertical;
			}
			moveDirection = moveDirection * speed;
			if (Input.GetButton ("Jump")) {
				moveDirection.y = jumpSpeed;
			}//End jump statement
		}//End move statement
		moveDirection.y -= gravity * Time.deltaTime;
		chara.Move(moveDirection * Time.deltaTime);
	}
}
