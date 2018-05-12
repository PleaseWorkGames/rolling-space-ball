using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[
	RequireComponent(typeof(Rigidbody2D))
]
public class PlayerController : MonoBehaviour {

	public float moveScale = 1F;

	public bool floating = true;

	private bool active = true;

	private Rigidbody2D rb;


	// Use this for initialization
	void Start () {
		rb = this.GetComponent<Rigidbody2D>() as Rigidbody2D;
		
		rb.isKinematic = floating;
	}

	// debug implementation to allow ball to move with any arrow key if floating is true
	void FixedUpdate(){

		if(floating) {
			rb.MovePosition(
				new Vector2(rb.position.x + (this.Left() + this.Right()) * moveScale,
							rb.position.y + (this.Up() + this.Down()) * moveScale
							)
			);
		}
	}

	public float Up(){
		return active && Input.GetAxis("Vertical")>0?Input.GetAxis("Vertical"):0;
	}

	public float Down(){
		return active && Input.GetAxis("Vertical")<0?Input.GetAxis("Vertical"):0;
	}

	public float Left(){
		return active && Input.GetAxis("Horizontal")<0?Input.GetAxis("Horizontal"):0;
	}

	public float Right(){
		return active && Input.GetAxis("Horizontal")>0?Input.GetAxis("Horizontal"):0;
	}

	public bool Jump(){
		return active && 
			(
				Input.GetKeyDown(KeyCode.Space) ||
				Input.GetKeyDown(KeyCode.UpArrow) 
			);
	}
}
