﻿using System.Collections;
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
		float degree = 90f;

		if (horizontal != 0 || vertical != 0)
		{
			anim.Play("Run");
		}
		else
		{
			transform.rotation = Quaternion.Euler(0, degree, 0);
			anim.Play("Idle");
		}

		if (jump)
			anim.Play("Runtojumpspring");

		transform.position += new Vector3(horizontal * (speed * Time.deltaTime), (jump ? jumpSpeed * Time.deltaTime : 0), vertical * (speed * Time.deltaTime));
		if (horizontal != 0)
			transform.rotation = Quaternion.Euler(0, degree * horizontal, 0);


		if (onPipe && Input.GetKeyDown(KeyCode.X))
		{
			Debug.Log("pressed the key");

			// change camera to show second scene
			secondCamera.SetActive(true);
			mainCamera.SetActive(false);

			// also change the character position to the second scene position
			var pipe_pos = GameObject.Find("BlueGround").transform.position;

			//this.transform.position = new Vector3(55, -5, 1);
			Debug.Log(pipe_pos);
			this.transform.position = pipe_pos + new Vector3(14, -4, 0);
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

		if (collision.gameObject.CompareTag(TagNames.UnusedBox.ToString()))
		{
			Debug.Log("Triggered a question box");
			var box = collision.gameObject.GetComponent<QuestionController>();
			box.UnusedBoxMove();
		}

		if (collision.gameObject.CompareTag(TagNames.Pipe.ToString()))
		{
			Debug.Log("Triggered the pipe");
			onPipe = true;
		}

		if (collision.gameObject.CompareTag(TagNames.SecondPipe.ToString()))
		{
			Debug.Log("Triggered second world pipe");

			// change camera to show first scene
			secondCamera.SetActive(false);
			mainCamera.SetActive(true);

			// also change the character position to the second scene position
			var pipe_pos = GameObject.Find("ExitPipe").transform.position;

			//this.transform.position = new Vector3(-15, 3, 1);
			Debug.Log(pipe_pos);
			this.transform.position = pipe_pos + new Vector3(5, 2, 0);

		}

		if (collision.gameObject.CompareTag(TagNames.Coin.ToString()))
		{
			var coin = collision.gameObject.GetComponent<CoinController>();
			coin.PlaySound();

			Debug.Log("Triggered the coin");
			eventSystem.OnCoinTrigger.Invoke();
			collision.gameObject.SetActive(false);
		}

		if (collision.gameObject.CompareTag(TagNames.Red.ToString()))
		{
			Debug.Log("Triggered the red slime");
			collision.gameObject.SetActive(false);
		}

		if (collision.gameObject.CompareTag(TagNames.Mushroom.ToString()))
		{
			Debug.Log("Triggered mushroom");
			transform.localScale = new Vector3(0.4f, 0.25f, 0.4f);
			collision.gameObject.SetActive(false);
		}

		if (collision.gameObject.CompareTag(TagNames.Enemy.ToString()))
		{
			Debug.Log("Triggered an enemy");
			eventSystem.OnHeartDecrease.Invoke();
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
