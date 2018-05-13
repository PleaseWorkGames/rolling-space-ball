using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class Multiplier : TextAbstract {

	private static bool loadedAlready = false;
	
	void Awake()
	{
		if (loadedAlready) {
			return;
		}

		EventBus.listenFor("multiplierChange2", this.changeMultiplierText);
		loadedAlready = true;
	}
	
	protected new void Start()
	{
		base.Start();
		DontDestroyOnLoad(text);
	}

	private void changeMultiplierText([CanBeNull] Dictionary<string, object> parameters)
	{
		text.text = "x" + (float) parameters["multiplier"];
	}
}
