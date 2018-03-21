using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class ScoreScript : MonoBehaviour {

    public GameObject name;
    public GameObject score;

    public void SetScore(string _name, string _score)
    {
        this.name.GetComponent<Text>().text = _name;
        this.score.GetComponent<Text>().text = _score;
    }

}
