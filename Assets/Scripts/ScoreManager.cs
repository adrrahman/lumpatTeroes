using System.Collections;
using UnityEngine;
using UnityEngine.UI;

public class ScoreManager : MonoBehaviour {
	public static float scoreTime;

	Text text;

	void Start() {
		text = GetComponent<Text> ();
		scoreTime = PlayerPrefs.GetFloat("Scoretime");
		// scoreTime = 0;
	}

	void Update() {
		if (scoreTime < 0)
			scoreTime = 0;

		text.text = scoreTime.ToString("#.00");
		scoreTime += Time.deltaTime;

	}

	public static void reduceTime( float timeToReduce) {
		scoreTime -= timeToReduce;
	}

	public static void reset() {
		scoreTime = 0;
	}
}
