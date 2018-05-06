using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class Music : MonoBehaviour
{
 	AudioSource audioClip;
	
	void Start ()
	{
		this.audioClip = GetComponent<AudioSource>() as AudioSource;
		EventBus.listenFor("multiplierChange", this.updatePitch);
	}
	
	public void updatePitch([CanBeNull] Dictionary<string, object> parameters)
	{
		audioClip.pitch = (float) parameters["multiplier"];
	}
}
