using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventSystemCustom : MonoBehaviour
{
	//public UnityEvent OnCloneStickyPlatformEnter;
	public UnityEvent OnBrickTrigger;

	void Awake()
    {
		OnBrickTrigger = new UnityEvent();
  //      OnCloneStickyPlatformEnter = new UnityEvent();
		//OnKeyTrigger = new UnityEvent();
		//OnWinCondition = new UnityEvent();
		//OnLooseCondition = new UnityEvent();
		//OnSpecialKeyTrigger = new UnityEvent();
		//OnSpecialKeyDecrease = new UnityEvent();
	}
}
