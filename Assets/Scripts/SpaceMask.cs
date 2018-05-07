using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpaceMask : MonoBehaviour
{
	private Mask overlayMask;
	private Text text;
	
	void Start ()
	{
		this.overlayMask = GetComponent<Mask>();
		this.text = GetComponentInChildren<Text>();
	}
	
	/**
	 * TODO - Move overlay mask based on position of ball 
	 */
	void Update ()
	{
		Vector2 originalTextPosition = text.transform.position;
		
		overlayMask.transform.position = new Vector2(
			overlayMask.transform.position.x + 1.0f,
			overlayMask.transform.position.y
		);

		// reset position on child text (TODO - there's gotta be a better way to do this)
		text.transform.position = originalTextPosition;
	}
}
