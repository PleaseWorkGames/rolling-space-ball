using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[
	RequireComponent(typeof(PlayerController)),
	RequireComponent(typeof(Rigidbody2D))
]
public class Jumpable : MonoBehaviour {

	public float jumpMultiplier = 100;
	public bool jumping = false;

	private PlayerController pc;
	private Rigidbody2D rb;

	// Use this for initialization
	void Start () {
		pc = GetComponent<PlayerController>() as PlayerController;
		rb = GetComponent<Rigidbody2D>() as Rigidbody2D;
	}
	
	void FixedUpdate () {
		
		if(pc.Jump()) {
			rb.AddForce(new Vector2(
				0,
				1 * jumpMultiplier
			));
			jumping = true;
		}
	}
}
