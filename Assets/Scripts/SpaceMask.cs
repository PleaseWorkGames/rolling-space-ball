using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class SpaceMask : MonoBehaviour
{
	private Mask overlayMask;
	private Text text;
	
	private float screenWidth;
	private float textWidth;
	private float originalPlayerPositionX;
	private float originalOverlayMaskPositionX;

	public Player player;
	public Camera gameCamera;
	
	void Start ()
	{
		this.overlayMask = GetComponent<Mask>();
		this.text = GetComponentInChildren<Text>();
		
		this.originalPlayerPositionX = gameCamera.WorldToScreenPoint(this.player.transform.position).x;
		this.originalOverlayMaskPositionX = this.overlayMask.transform.localPosition.x;
		
		this.screenWidth = Screen.width;
		this.textWidth = this.text.GetComponent<RectTransform>().rect.width;
	}
	
	/**
	 * Move overlay mask based on position of ball 
	 */
	void FixedUpdate ()
	{
		float currentPlayerPositionX = gameCamera.WorldToScreenPoint(this.player.transform.position).x;
		float differencePlayerPositionX = this.originalPlayerPositionX - currentPlayerPositionX;

		float overlayMaskPositionXDestination = this.originalOverlayMaskPositionX - differencePlayerPositionX * ((textWidth / 2) / screenWidth); // TODO - figure out why -10 is left side of stage for player and overlay mask  
		
		// move overlay mask to new position based on ball position.  this requires moving the mask and then moving the children back to original positions, since it moves both and I haven't looked into how to do this better
		Vector3 originalTextPosition = text.transform.position;
		
		overlayMask.transform.localPosition = new Vector2(
			overlayMaskPositionXDestination,
			overlayMask.transform.localPosition.y
		);

		// reset position on child text (TODO - there's gotta be a better way to do this)
		text.transform.position = originalTextPosition;
	}
}
