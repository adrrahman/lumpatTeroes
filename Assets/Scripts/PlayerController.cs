using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerController : MonoBehaviour {

	public float moveSpeed;
	private float moveVelocity;
	public float jumpHeight;

	public Transform groundCheck;
	public float groundCheckRadius;
	public LayerMask whatIsGround;
	private bool grounded;

	private bool doubleJumped;
	private bool isOnPlatform;
	private Animator anim;

	private Rigidbody2D myrigidbody2D;

	public bool onLadder;
	public float climbSpeed;
	private float climbVelocity;
	private float gravityStore;
	// Use this for initialization
	void Start () {
		anim = GetComponent<Animator> ();

		myrigidbody2D = GetComponent<Rigidbody2D> ();

		gravityStore = myrigidbody2D.gravityScale;
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

		moveVelocity = 0f;
		if (Input.GetKey (KeyCode.RightArrow)) {
			// GetComponent<Rigidbody2D> ().velocity = new Vector2 (moveSpeed, GetComponent<Rigidbody2D> ().velocity.y);
			moveVelocity = moveSpeed;
		}

		if (Input.GetKey (KeyCode.LeftArrow)) {
			// GetComponent<Rigidbody2D> ().velocity = new Vector2 (-moveSpeed, GetComponent<Rigidbody2D> ().velocity.y);
			moveVelocity = -moveSpeed;
		}
		GetComponent<Rigidbody2D> ().velocity  = new Vector2 (moveVelocity, GetComponent<Rigidbody2D> ().velocity.y);

		if (onLadder) {
			myrigidbody2D.gravityScale = 0f;

			climbVelocity = climbSpeed * Input.GetAxisRaw ("Vertical");

			myrigidbody2D.velocity = new Vector2 (GetComponent<Rigidbody2D> ().velocity.x, climbVelocity); 
		}

		if (!onLadder) {
			myrigidbody2D.gravityScale = gravityStore;
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
