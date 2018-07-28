using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Play : MonoBehaviour {
  
  public Transform capsule;
  Animator anim;
  float x = 0, y = 0, z = -1;
  Rigidbody rb;
  
	// Use this for initialization
	void Start () {
		rb = GetComponent<Rigidbody>();
    //transform.localPosition = new Vector3(x, y + 1.4f, z);
	}
	
	// Update is called once per frame
	void Update () {
    if(Input.GetKey("left")) {
      Vector3 angles = transform.eulerAngles;
      angles.y += 6;
      transform.eulerAngles = angles;
      Debug.Log(transform.eulerAngles);
    }
    
    z += -0.01f;
    Vector3 f = transform.forward;
    f = f * 0.8f;
		//transform.localPosition += new Vector3(f.x, 0, f.z);
    Vector3 v = rb.velocity;
    v = f;
    rb.velocity = v;
    Debug.Log(v);
	}
}
