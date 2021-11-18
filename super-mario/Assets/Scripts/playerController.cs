using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
	public float speed = 5.0f;
	public float jumpSpeed = 1.0f;


	private void Update()
	{
		var horizontal = Input.GetAxis("Horizontal");
		var vertical = Input.GetAxis("Vertical");
		var jump = Input.GetButton("Jump");
		transform.Translate(new Vector3(horizontal * (speed * Time.deltaTime), (jump ? jumpSpeed * Time.deltaTime : 0), vertical* (speed * Time.deltaTime)) );
		
	}

	private void OnTriggerEnter(Collider collision)
	{
		if (collision.gameObject.CompareTag(TagNames.Brick.ToString()))
		{
			Debug.Log("Triggered a Brick");
			var brick = collision.gameObject.GetComponent<BrickController>();
			//brick.MoveDestroy();
			StartCoroutine(brick.Move());
			
		}

	}
}
