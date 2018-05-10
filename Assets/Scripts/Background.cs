using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[
	RequireComponent(typeof(SpriteRenderer))
]
public class Background : MonoBehaviour {

	private SpriteRenderer spriteRenderer;
	// Use this for initialization
	void Start () {
		spriteRenderer = GetComponent<SpriteRenderer>() as SpriteRenderer;

		float worldScreenHeight = Camera.main.orthographicSize * 2.0F;
		float worldScreenWidth = worldScreenHeight / Screen.height * Screen.width;

		spriteRenderer.size = new Vector2( worldScreenWidth, worldScreenHeight );

		transform.position = new Vector2(0,0);
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
