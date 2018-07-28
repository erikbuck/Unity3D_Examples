using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;  // For DateTime

public class MerryGoRound : MonoBehaviour {

    public float bouncesRate = 1.0f;
    public float heightOfBounce = 1.0f;
    public Transform[] poles = new Transform[] { };

    float angle;
    const float degreesPerSecond = 10;

    // Use this for initialization
    void Start () {
        Debug.Log(poles.Length);

    }

    // Update is called once per frame
    void Update () {
        angle = Mathf.Repeat((float)DateTime.Now.TimeOfDay.TotalSeconds * degreesPerSecond, 360.0f);
        transform.localRotation = Quaternion.Euler(0f, angle, 0f);

        int numberOfPoles = poles.Length;
        if(numberOfPoles > 0)
        {
            float offsetPerPoleRad = (2f * Mathf.PI) / poles.Length;
            float angleRad = angle * 1.0f / (2f * Mathf.PI);
            for (int i = 0; i < poles.Length; ++i)
            {
                Transform pole = poles[i];
                if(pole)
                {
                    Vector3 pos = pole.localPosition;
                    pos.y = heightOfBounce * Mathf.Sin(bouncesRate * angleRad + (offsetPerPoleRad * i));
                    pole.localPosition = pos;
                }
            }
        }
    }
}
