using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class UiManager : MonoBehaviour
{
	public Text coinText;
    public EventSystemCustom eventSystem;

    void Start()
    {
        eventSystem.OnCoinTrigger.AddListener(UpdateCoinText);
	}

    public void UpdateCoinText()
    {
        //Debug.Log("UPDATE SCORE");
		var text = coinText.text.Split(':');
		int newValue = int.Parse(text[1]) + 1;
		coinText.text = "Coins:" + newValue.ToString();
	}

}
