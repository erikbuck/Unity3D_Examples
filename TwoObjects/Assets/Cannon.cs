using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Cannon : MonoBehaviour {

  public Transform ball;
  public PowerBar powerBar;
  public PowerBar angleGauge;
  public float maxValue = 100.0f;
  public float maxAngleValue = 80.0f;
  
  Rigidbody rb;
  
	// Use this for initialization
	void Start () {
		rb = ball.GetComponent<Rigidbody>();
	}
	
  void Fire() {
    float power = powerBar.powerLevel;
    
    rb.AddForce(ball.transform.forward * power * maxValue);
    rb.useGravity = true;
  }
  
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown("space")) {
      Fire();
    }

    float angle = angleGauge.powerLevel;
		
    transform.eulerAngles = new Vector3(-angle * maxAngleValue, 0, 0);
	}
}
