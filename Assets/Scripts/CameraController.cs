using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour {

	public PlayerController player;
	public bool isFollowing;

	public float xOffset;
	public float yOffset;

	public float positionY;

	// Use this for initialization
	void Start () {
		player = FindObjectOfType<PlayerController> ();

		isFollowing = true;
		positionY = transform.position.y + yOffset;
	}
	
	// Update is called once per frame
	void Update () {
		if (isFollowing)
			transform.position = new Vector3 (player.transform.position.x + xOffset, positionY, transform.position.z);
	}
}
