using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[
	RequireComponent(typeof(EdgeCollider2D))
]
public class Destroyer : MonoBehaviour {

	private EdgeCollider2D ec;
	void Start() {
		ec = GetComponent<EdgeCollider2D>() as EdgeCollider2D; 
		Vector2[] points = new Vector2[3];

		//Top left of screen
		points[0] = Camera.main.ViewportToWorldPoint(new Vector3(
			0,
			1,
			Camera.main.nearClipPlane
		));

		//Bottom left of screen
		points[1] = Camera.main.ViewportToWorldPoint(new Vector3(
			0,
			0,
			Camera.main.nearClipPlane
		));

		//Bottom right of screen
		points[2] = Camera.main.ViewportToWorldPoint(new Vector3(
			1,
			0,
			Camera.main.nearClipPlane
		));

		ec.points = points;

		ec.isTrigger = true;
	}
	void OnTriggerExit2D(Collider2D other) {

		if(other.gameObject.GetComponent<Player>() != null ) {
			World.reloadScene(); 
		}
		else {
			Destroy(other.gameObject);
		}
	}
}
