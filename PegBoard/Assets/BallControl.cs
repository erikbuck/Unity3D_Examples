using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BallControl : MonoBehaviour {

	public Transform ball;
	public Transform guideRail;
	public float impulseMagnitude = 80.0f;
	public int score;
	public ScoreDisplay scoreDisplay;
	public Transform[] binLeftEdges;
	public int defaultBinScore = 15;
	public int[] binScores;

	Vector3 startPosition;

	// Use this for initialization
	void Start () {
		startPosition = ball.localPosition;
	}
	
	// Update is called once per frame
	void Update () {
		if (Input.GetKeyDown("space"))
		{
			bool shouldApplyForce = true;
			if(guideRail) {
				// guiderail has value. Only apply force if ball is to right
				// of guardRail
				shouldApplyForce = (ball.position.x > guideRail.position.x);
			}

			if(shouldApplyForce) {
				Rigidbody rb = ball.gameObject.GetComponent<Rigidbody>();
				rb.AddForce(transform.forward * -impulseMagnitude, 
						ForceMode.Impulse);
			}
		}

		if(ball.position.y < -25.0f) 
		{   // Ball fell off bottom of board
			int slot = 0;
			bool done = false;

			// Find slot ball fell trough by comparing if ball
			// is to the right of a bin left edge
			// Bins need to be in binLeftEdges from right to left
			for(int i = 0; i < binLeftEdges.Length && !done; ++i) {
				if(ball.position.x > binLeftEdges[i].position.x) {
					slot = i;
					done = true;
				}
			}
			//Debug.Log(string.Format("{0}: {1}", ball.position.x, slot));

			// Apply score based on the slot ball fell through (scores 
			// correspond to bins)
			if(slot < binScores.Length) {
				score += binScores[slot];
			} else {
				score += defaultBinScore;
			}
			if(scoreDisplay) {
				scoreDisplay.setScore(score);
			}
			ball.localPosition = startPosition;
		}
	}
}
