using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[
	RequireComponent(typeof(Rigidbody2D)),
	RequireComponent(typeof(PolygonCollider2D)),
	RequireComponent(typeof(SpriteRenderer)),
	RequireComponent(typeof(Translatable))
]
public class Ground : MonoBehaviour {

	private PolygonCollider2D pc;

	// Use this for initialization
	void Start () {
		SpriteRenderer sr = GetComponent<SpriteRenderer>() as SpriteRenderer;

		Sprite sprite = sr.sprite;

		pc = GetComponent<PolygonCollider2D>() as PolygonCollider2D;

	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
