using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class QuestionController : MonoBehaviour
{
	public int hitCount = 2;
    // Start is called before the first frame update
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {

        
    }

	public void UnusedBoxMove()
	{
		if (hitCount > 0)
		{
			StartCoroutine(Move());
			hitCount--;
		}
		else
		{
			Debug.Log("no more move");
			// disable unused box, enable used box
			var b1 = this.transform.GetChild(0).gameObject;
			var b2 = this.transform.GetChild(1).gameObject;
			var mushroom = this.transform.GetChild(2).gameObject;

			b1.SetActive(false);
			b2.SetActive(true);
			if(hitCount == 0)
			{
				mushroom.SetActive(true);
			}
			hitCount--;
		}
	}

	private IEnumerator Move()
	{
		//Debug.Log("moving question box upward");
		//Debug.Log(hitCount);
		transform.GetComponent<Collider>().isTrigger = false; //player doesn't go through the brick
		this.transform.position += new Vector3(0f, 0.2f, 0f);
		yield return new WaitForSeconds(0.1f);

		this.transform.position += new Vector3(0, -0.2f, 0);
		yield return new WaitForSeconds(0.25f);
		transform.GetComponent<Collider>().isTrigger = true;

		//Destroy(gameObject);
	}
}
