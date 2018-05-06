using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[
	RequireComponent(typeof(Collider2D))
]
public class Generator : MonoBehaviour {

	public Ground ground;
	public TranslatableValue translatableDistance;

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
		float offset = ec.bounds.extents.x;

		// Set new position of new ground
		newGround.transform.localPosition = new Vector2(
			other.bounds.max.x + offset,
			other.transform.position.y
		);
	}

}
