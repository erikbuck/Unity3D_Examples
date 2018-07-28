using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PowerBar : MonoBehaviour {

	public Transform barBox;
	public float powerLevel = 0.1f;
  public string upKey = "up";
  public string downKey = "down";

	// Use this for initialization
	void Start () {
		barBox.localScale = new Vector3(1.0f, powerLevel, 1.0f);
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown(upKey)) {
			powerLevel += 0.1f;
		} else if(Input.GetKeyDown(downKey)) {
			powerLevel -= 0.1f;
		}
		powerLevel = Mathf.Max(0.1f, Mathf.Min(1.0f, powerLevel));

		barBox.localScale = new Vector3(1.0f, powerLevel, 1.0f);		
	}
}
