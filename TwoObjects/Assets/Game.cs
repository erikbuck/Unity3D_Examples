using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Game : MonoBehaviour {

  public UnityEngine.UI.Text infoText;

  IEnumerator FadeTo(float aValue, float aTime, float waitTime=2.0f)
  {
      yield return new WaitForSeconds(waitTime);
      float alpha = infoText.color.a;
      for (float t = 0.0f; t < 1.0f; t += Time.deltaTime / aTime)
      {
          Color newColor = new Color(0, 0, 0, Mathf.Lerp(alpha,aValue,t));
          infoText.color = newColor;
          yield return null;
      }
  }  
  
	// Use this for initialization
	void Start () {
    infoText.text = "Start Playing";
    infoText.color = new Color(0, 0, 0, 1);
    StartCoroutine(FadeTo(0.0f, 2.0f));
	}
	
	// Update is called once per frame
	void Update () {
		if(Input.GetKeyDown("a")) {
        Time.timeScale = 0.0f;
        infoText.text = "Paused";
        infoText.color = new Color(0, 0, 0, 1);
		} else if(Input.GetKeyDown("d")) {
        Time.timeScale = 1.0f;
        infoText.text = "Running";
        infoText.color = new Color(0, 0, 0, 1);
        StartCoroutine(FadeTo(0.0f, 1.0f));
		}
    
	}
}
