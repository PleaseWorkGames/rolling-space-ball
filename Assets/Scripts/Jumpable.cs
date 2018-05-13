using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[
	RequireComponent(typeof(PlayerController)),
	RequireComponent(typeof(Rigidbody2D)),
	RequireComponent(typeof(Collider2D))
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
	
	void Update () {
		if(pc.Jump() && !jumping) {
			rb.AddForce(new Vector2(
				.15f * jumpMultiplier,
				1 * jumpMultiplier
			));
			jumping = true;
		}
	}

	void OnCollisionEnter2D(Collision2D other){
		Ground ground = other.gameObject.GetComponent<Ground>() as Ground;

		if(ground != null) {
			jumping = false;
		}
	}
}
