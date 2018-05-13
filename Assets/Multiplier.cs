using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;
using UnityEngine.UI;

public class Multiplier : MonoBehaviour {

	private static bool loadedAlready = false;
	
	private static Text text;

	void Awake()
	{
		if (loadedAlready) {
			return;
		}

		EventBus.listenFor("multiplierChange2", this.changeMultiplierText);
		loadedAlready = true;
	}
	
	void Start()
	{
		text = gameObject.GetComponent<Text>() as Text;
	}

	private void changeMultiplierText([CanBeNull] Dictionary<string, object> parameters)
	{
		text.text = "x" + (float) parameters["multiplier"];
	}
}
