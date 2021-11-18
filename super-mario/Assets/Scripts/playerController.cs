using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
	//CharacterController characterController;

	//public float speed = 6.0f;
	//public float jumpSpeed = 8.0f;
	//public float gravity = 20.0f;

	//private Vector3 moveDirection = Vector3.zero;

	//void Start()
	//{
	//	characterController = GetComponent<CharacterController>();
	//}

	//void Update()
	//{
	//	if (characterController.isGrounded)
	//	{
	//		// We are grounded, so recalculate
	//		// move direction directly from axes

	//		moveDirection = new Vector3(Input.GetAxis("Horizontal"), 0.0f, Input.GetAxis("Vertical"));
	//		moveDirection *= speed;

	//		if (Input.GetButton("Jump"))
	//		{
	//			moveDirection.y = jumpSpeed;
	//		}
	//	}

	//	// Apply gravity. Gravity is multiplied by deltaTime twice (once here, and once below
	//	// when the moveDirection is multiplied by deltaTime). This is because gravity should be applied
	//	// as an acceleration (ms^-2)
	//	moveDirection.y -= gravity * Time.deltaTime;

	//	// Move the controller
	//	characterController.Move(moveDirection * Time.deltaTime);
	//}
	public float speed = 5.0f;
	public float jumpSpeed = 1.0f;

	private void Update()
	{
		var horizontal = Input.GetAxis("Horizontal");
		var vertical = Input.GetAxis("Vertical");
		var jump = Input.GetButton("Jump");
		transform.Translate(new Vector3(horizontal * (speed * Time.deltaTime), (jump ? jumpSpeed * Time.deltaTime : 0), vertical* (speed * Time.deltaTime)) );
		//transform.Translate(new Vector3(horizontal, 0, vertical) * (speed * Time.deltaTime));
		//if(jump)
		//	this.transform.position 
	}
}
