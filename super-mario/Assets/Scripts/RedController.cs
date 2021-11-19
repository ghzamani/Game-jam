using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RedController : MonoBehaviour
{
	float left = -30.5f;
	float right = -25.5f;
	float movingSpeed = 0.01f;
	float side = 1f;
	Vector3 moveVec;

    // Start is called before the first frame update
    void Start()
    {
		moveVec = new Vector3(movingSpeed, 0, 0);

    }

	// Update is called once per frame
	void Update()
	{
		if (side == 1)
			transform.position += moveVec;
		
		if (side == -1)
			transform.position -= moveVec;

		if (transform.position.x >= right)
			side = -1f;
		if (transform.position.x <= left)
			side = 1f;
	}

}
