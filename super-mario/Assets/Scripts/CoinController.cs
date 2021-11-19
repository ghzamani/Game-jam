using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinController : MonoBehaviour
{
	// Start is called before the first frame update
	public AudioSource coinSound;

    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
		transform.Rotate(0, 1, 0, Space.World);
    }

	public void PlaySound()
	{
		Debug.Log("called coin sound");
		coinSound.Play();
	}
}
