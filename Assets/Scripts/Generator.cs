using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[
	RequireComponent(typeof(EdgeCollider2D))
]
public class Generator : MonoBehaviour {

	public Ground ground;
	public TranslatableValue translatableDistance;

	public float maxGapDistance = 1.5f;

	public float minGapDistance = 0.5f;

	private EdgeCollider2D ec;

	void Start() {
		ec = GetComponent<EdgeCollider2D>() as EdgeCollider2D;

		Vector2[] points = new Vector2[2];

		//set top right
		points[0] = Camera.main.ViewportToWorldPoint(new Vector3(
			1,
			1,
			Camera.main.nearClipPlane
		));

		//set bottom right
		points[1] = Camera.main.ViewportToWorldPoint(new Vector3(
			1,
			0,
			Camera.main.nearClipPlane
		));

		ec.points = points;
	}

	void OnTriggerExit2D(Collider2D other) {

		// Create new ground
		Ground newGround = Instantiate(
			ground, 
			new Vector2(0,0),
			this.transform.rotation);

		// Set translatable value to the new ground
		Translatable tr = newGround.GetComponent<Translatable>() as Translatable;
		tr.translateDistance = translatableDistance;

		// Get the offset position for the new ground so there is no overlap
		Collider2D ec = newGround.GetComponent<Collider2D>() as Collider2D;
		float offset = ec.bounds.extents.x + Random.Range(minGapDistance,maxGapDistance);

		// Set new position of new ground
		newGround.transform.localPosition = new Vector2(
			other.bounds.max.x + offset,
			other.transform.position.y
		);
	}

}
