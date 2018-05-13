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

		if(sr.drawMode != SpriteDrawMode.Simple) {
			Vector2[] points = pc.points;

			for(int i=0; i<points.Length;i++){
				points[i] = new Vector2(
					points[i].x * sr.size.x,
					points[i].y * sr.size.y
				);
			}
			
			pc.points = points;
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
