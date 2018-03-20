using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float moveSpeed;
	public float jumpHeight;

	public Transform groundCheck;
	public float groundCheckRadius;
	public LayerMask whatIsGround;
	private bool grounded;

	private bool doubleJumped;
	private bool isOnPlatform;
	private Animator anim;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();
	}

	void FixedUpdate () {
		grounded = Physics2D.OverlapCircle (groundCheck.position, groundCheckRadius, whatIsGround);
	}
	
	// Update is called once per frame
	void Update () {
		if (grounded)
			doubleJumped = false;
		
		if (Input.GetKeyDown (KeyCode.Space) && grounded) {
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (GetComponent<Rigidbody2D> ().velocity.x, jumpHeight);
		}

		if (Input.GetKeyDown (KeyCode.Space) && !doubleJumped && !grounded) {
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (GetComponent<Rigidbody2D> ().velocity.x, jumpHeight);
			doubleJumped = true;
		}

		if (Input.GetKey (KeyCode.RightArrow)) {
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (moveSpeed, GetComponent<Rigidbody2D> ().velocity.y);
		}

		if (Input.GetKey (KeyCode.LeftArrow)) {
			GetComponent<Rigidbody2D> ().velocity = new Vector2 (-moveSpeed, GetComponent<Rigidbody2D> ().velocity.y);
		}

//		anim.SetFloat ("Speed", Mathf.Abs(GetComponent<Rigidbody2D> ().velocity.x));
	}

	void OnCollisionEnter2D(Collision2D thing) {
		isOnPlatform = (thing.transform.tag == "MovingPlatform");
		Debug.Log (thing.transform.tag);
		if (thing.transform.tag == "MovingPlatform") {
			transform.parent = thing.transform;
		}
	}

	void OnCollisionExit2D(Collision2D thing) {
		if (thing.transform.tag == "MovingPlatform") {
			transform.parent = null;
		}
	}
}
