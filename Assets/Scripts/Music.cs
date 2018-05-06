using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class Music : MonoBehaviour
{
	private AudioSource audioClip;
	
	void Start ()
	{
		AudioSource audioClip = GetComponent<AudioSource>();
		/*
		EventBus.listenFor("multiplierChange", this.updatePitch);
		*/
	}
	
	/*
	public void updatePitch([CanBeNull] Dictionary<string, dynamic> parameters)
	{
		audioClip.pitch = parameters["multiplier"];
	}
	*/
}
