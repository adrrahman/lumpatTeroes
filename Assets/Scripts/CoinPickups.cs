using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CoinPickups : MonoBehaviour {
	public int reduceTime;
	public AudioSource coinAudio;

	void OnTriggerEnter2D (Collider2D thing) {
		if (thing.GetComponent<PlayerController>() == null) {
			return;
		}

		coinAudio.Play();

		ScoreManager.reduceTime(reduceTime);

		Destroy(gameObject);
	}
}
