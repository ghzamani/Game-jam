using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EventSystemCustom : MonoBehaviour
{
	public UnityEvent OnCoinTrigger;
	public UnityEvent OnHeartDecrease;

	void Awake()
    {
		OnCoinTrigger = new UnityEvent();
		OnHeartDecrease = new UnityEvent();
	}
}
