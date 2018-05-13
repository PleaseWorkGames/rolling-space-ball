using System.Collections;
using System.Collections.Generic;
using JetBrains.Annotations;
using UnityEngine;

public class Music : MonoBehaviour
{
 	private static AudioSource audioClip;
	
	private static bool loadedAlready = false;
	
	void Awake()
	{
		if (loadedAlready) {
			return;
		}
		
		audioClip = GetComponent<AudioSource>() as AudioSource;
		DontDestroyOnLoad(audioClip);
		EventBus.listenFor("multiplierChange", this.updatePitch);
		
		loadedAlready = true;
	}

	public void start()
	{
		audioClip.pitch = (float) 3 / 2;
	}
	
	public void updatePitch([CanBeNull] Dictionary<string, object> parameters)
	{
		audioClip.pitch = (float) parameters["multiplier"] / 2;
	}
}
