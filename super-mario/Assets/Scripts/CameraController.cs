using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
	public GameObject player;

	private float Distance = 14.0f;
	private float CameraY = 8.0f;


	void Update()
	{
		Vector3 pos = new Vector3(player.transform.position.x + 7, 0, player.transform.position.z - Distance);
		transform.position = pos;
	}

	// LateUpdate is called after Update each frame
	void LateUpdate()
	{
		transform.position += new Vector3(0, CameraY, 0);
	}

}
