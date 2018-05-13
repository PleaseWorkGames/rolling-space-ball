using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[
	RequireComponent(typeof(Translatable))
]
public class Midground : Background {

	public int position = 0;

	// Use this for initialization
	void Start () {
		base.InitSpriteRenderer();

		float worldScreenHeight = Camera.main.orthographicSize * 2.0F;
		float worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;

		spriteRenderer.size = new Vector2( 
			worldScreenWidth/2F,
			spriteRenderer.size.y
		);

		transform.position = new Vector2(
			-spriteRenderer.size.x/2 + spriteRenderer.size.x*position,
			spriteRenderer.transform.position.y - worldScreenHeight/3f
		);

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
