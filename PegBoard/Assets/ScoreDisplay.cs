using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ScoreDisplay : MonoBehaviour {

	public UnityEngine.UI.Text scoreText;
	public UnityEngine.UI.Text scoreTextBackground;

	public void setScore(int aScore) {
		string scoreString = string.Format("{0:0000}", aScore);
		scoreText.text = scoreString;
		scoreTextBackground.text = scoreString;
	}

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
		
	}
}
