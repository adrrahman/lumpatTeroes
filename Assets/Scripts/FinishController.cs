using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class FinishController : MonoBehaviour {
	private Scene scene;
	// Use this for initialization
	void Start () {
		scene = SceneManager.GetActiveScene();
	}
	
	// Update is called once per frame
	void Update () {
		
	}

	void OnTriggerEnter2D (Collider2D thing) {
		string sceneName = scene.name;
		Debug.Log (sceneName);
		PlayerPrefs.SetFloat ("Scoretime",ScoreManager.scoreTime);
		if (sceneName == "Scene1") {
			Application.LoadLevel ("Scene2");
		}
	}
}
