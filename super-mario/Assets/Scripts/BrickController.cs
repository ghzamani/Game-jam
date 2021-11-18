using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BrickController : MonoBehaviour
{
	// Start is called before the first frame update
	void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		
	}

	public IEnumerator Move()
	{
		Debug.Log("moving upward");
		transform.GetComponent<Collider>().isTrigger = false; //player doesn't go through the brick
		this.transform.position += new Vector3(0f, 0.2f, 0f);
		yield return new WaitForSeconds(0.1f);

		this.transform.position += new Vector3(0, -0.2f, 0);
		yield return new WaitForSeconds(0.25f);
		transform.GetComponent<Collider>().isTrigger = true;

		//Destroy(gameObject);

	}

	// if mario is big, the block destroys after moving
	public void MoveDestroy()
	{
		Debug.Log("destroy");
		StartCoroutine(Move());
		Destroy(gameObject);
	}
}
