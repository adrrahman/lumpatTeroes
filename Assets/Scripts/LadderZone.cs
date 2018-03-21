using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LadderZone : MonoBehaviour {

	private PlayerController thePlayer;

	// Use this for initialization
	void Start () {
		thePlayer = FindObjectOfType<PlayerController> ();
	}
	
	void OnTriggerEnter2D (Collider2D thing) {
		Debug.Log (thing.name);
		if (thing.name == "player") {
			thePlayer.onLadder = true;
		}
	}

	void OnTriggerExit2D (Collider2D thing) {
		if (thing.name == "player") {
			thePlayer.onLadder = false;
		}
	}
}
