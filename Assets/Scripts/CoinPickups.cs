using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickups : MonoBehaviour {
	public int reduceTime;

	void OnTriggerEnter2D (Collider2D thing) {
		if (thing.GetComponent<PlayerController>() == null) {
			return;
		}

		ScoreManager.reduceTime(reduceTime);

		Destroy(gameObject);
	}
}
