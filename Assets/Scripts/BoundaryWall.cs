using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[
	RequireComponent(typeof(EdgeCollider2D))
]
public class BoundaryWall : MonoBehaviour {

	private EdgeCollider2D edgeCollider;
	// Use this for initialization
	void Start () {
		edgeCollider = GetComponent<EdgeCollider2D>() as EdgeCollider2D;

		Vector2[] points = {
				Camera.main.ViewportToWorldPoint(new Vector2(0,0)),
				Camera.main.ViewportToWorldPoint(new Vector2(0,1)),
				Camera.main.ViewportToWorldPoint(new Vector2(1,1)),
				Camera.main.ViewportToWorldPoint(new Vector2(1,0))
		};

		edgeCollider.points = points;
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
