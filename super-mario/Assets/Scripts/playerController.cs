using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{
	public float speed = 5.0f;
	public float jumpSpeed = 1.0f;
	private bool onPipe = false;

	Animation anim;

	public GameObject mainCamera;
	public GameObject secondCamera;

	public EventSystemCustom eventSystem;


	void Start()
	{
		anim = GetComponent<Animation>();
	}

	private void Update()
	{
		var horizontal = Input.GetAxis("Horizontal");
		var vertical = Input.GetAxis("Vertical");
		var jump = Input.GetButton("Jump");

		// y rotate = -90
		// does not work :(
		//float degree = 90f;
		//float side = 1;
		//if (Input.GetKey(KeyCode.UpArrow))
		//{
		//	//transform.Rotate(Vector3.up * degree * -1);
		//	//transform.rotation = Quaternion.LookRotation(new Vector3(0, degree, 0));
		//	side = 1;
		//	//transform.rotation = Quaternion.Euler(0, degree, 0);
		//	//mySpriteRenderer.flipY = false;
		//}

		//if (Input.GetKey(KeyCode.DownArrow))
		//{
		//	//transform.Rotate(Vector3.up * degree * -1);
		//	//transform.rotation = Quaternion.LookRotation(new Vector3(degree * -1, 0, 0));
		//	side = -1;
		//	//transform.rotation = Quaternion.Euler(0, degree * -1, 0);
		//	//mySpriteRenderer.flipY = true;

		//}

		if (horizontal != 0 || vertical != 0)
		{
			anim.Play("Run");		
			//transform.forward = new Vector3(degree * side, 0, 0);
		}
		else anim.Play("Idle");

		if (jump)
			anim.Play("Runtojumpspring");

		transform.Translate(new Vector3(horizontal * (speed * Time.deltaTime), (jump ? jumpSpeed * Time.deltaTime : 0), vertical * (speed * Time.deltaTime)));


		if (onPipe && Input.GetKeyDown(KeyCode.X))
		{
			Debug.Log("pressed the key");

			// change camera to show second scene
			secondCamera.SetActive(true);
			mainCamera.SetActive(false);

			// also change the character position
			this.transform.position = new Vector3(55, -5, 1);
		}

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

		if (collision.gameObject.CompareTag(TagNames.Pipe.ToString()))
		{
			Debug.Log("Triggered the pipe");
			onPipe = true;
		}

		if (collision.gameObject.CompareTag(TagNames.Coin.ToString()))
		{
			Debug.Log("Triggered the coin");
			eventSystem.OnCoinTrigger.Invoke();
			collision.gameObject.SetActive(false);
		}
	}

	private void OnTriggerExit(Collider collision)
	{
		if (collision.gameObject.CompareTag(TagNames.Pipe.ToString()))
		{
			onPipe = false;

		}
	}

}
