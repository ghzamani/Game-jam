using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
	public Text coinText;
	public Text heartsText;
	public EventSystemCustom eventSystem;

    void Start()
    {
        eventSystem.OnCoinTrigger.AddListener(UpdateCoinText);
        eventSystem.OnHeartDecrease.AddListener(DecreaseHeartText);
	}

    public void UpdateCoinText()
    {
        //Debug.Log("UPDATE SCORE");
		var text = coinText.text.Split(':');
		int newValue = int.Parse(text[1]) + 1;
		coinText.text = "Coins:" + newValue.ToString();
	}

	public void DecreaseHeartText()
	{
		//Debug.Log("UPDATE SCORE");
		var text = heartsText.text.Split(':');
		int newValue = int.Parse(text[1]) - 1;
		if(newValue == 0)
		{
			heartsText.text = "YOU LOOSED!";
			// find the enemy and deactive it
			var enemy = GameObject.Find("TurtleShell");
			enemy.SetActive(false);
			Time.timeScale = 0;
			
		}

		else heartsText.text = "Hearts:" + newValue.ToString();
	}
}
