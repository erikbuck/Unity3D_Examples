using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stir : MonoBehaviour {

	// Use this for initialization
	void Start () {
		
	}
	
	// Update is called once per frame
	void Update () {
    if(Input.anyKey || 0 < Input.touchCount)
    {
        if (Input.anyKey || Input.GetTouch(0).phase == TouchPhase.Began)
        {
          foreach (Transform child in transform) 
          {
            Rigidbody rb = child.gameObject.GetComponent<Rigidbody>();
            if(rb)
            {
              //Debug.Log(child.gameObject);

              rb.AddForce(Random.insideUnitSphere * 500);
            }
          }
        }
    }
	}
}
