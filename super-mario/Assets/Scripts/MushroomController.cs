using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MushroomController : MonoBehaviour
{
	float movingSpeed = 0.05f;
	float y = 2.3f;
	Vector3 moveVec;

	// Start is called before the first frame update
	void Start()
	{
		moveVec = new Vector3(movingSpeed, 0, 0);
	}

	// Update is called once per frame
	void Update()
	{
		if (transform.position.x < -37)
		{
			transform.position += moveVec;
		}

		else
		{
			if (transform.position.y > y)
			{
				moveVec = new Vector3(0, movingSpeed, 0);
				transform.position -= moveVec;
			}
		}
	}
}
