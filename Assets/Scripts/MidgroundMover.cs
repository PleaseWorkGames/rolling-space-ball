using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MidgroundMover : MonoBehaviour {

	public Midground midground;

	private LinkedList<Midground> midgroundList;
	// Use this for initialization
	void Start () {

		SpriteRenderer sr = midground.GetComponent<SpriteRenderer>() as SpriteRenderer;

		midgroundList = new LinkedList<Midground>();

		midgroundList.AddLast(midground);

		for(int i = 1; i<4; i++) {

			Midground section = GameObject.Instantiate(
				midground,
				new Vector2(0, 0),
				midground.transform.rotation,
				this.transform
			); 

			section.name = midground.name+"-"+i;
			section.position = i;

			midgroundList.AddLast(section);
		}
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void FixedUpdate() {
		Vector2 leftBoundary = Camera.main.ViewportToWorldPoint(new Vector3(
			0,
			.5F,
			Camera.main.nearClipPlane
		));

		Midground leftMostSection = midgroundList.First.Value;
		SpriteRenderer sr = leftMostSection.GetComponent<SpriteRenderer>() as SpriteRenderer;
		
		if( leftMostSection.transform.position.x + sr.size.x/2 < leftBoundary.x ) {
			
			midgroundList.RemoveFirst();

			leftMostSection.transform.position = new Vector2(
				midgroundList.Last.Value.transform.position.x + sr.size.x,
				leftMostSection.transform.position.y
			);

			midgroundList.AddLast(leftMostSection);
		} 
	}
}
