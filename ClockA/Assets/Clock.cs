using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;  // For DateTime

public class Clock : MonoBehaviour {
    public Transform secondsTransform, minutesTransform, hoursTransform;
    public bool isContinuous;

    const float degreesPerHour = 30f;
    const float degreesPerMinute = 6;
    const float degreesPerSecond = 6;

    // Use this for initialization
    void Start () {
        //Debug.Log(DateTime.Now.Hour);
    }

    // Update is called once per frame
    void Update()
    {
        if(isContinuous)
        {
            UpdateContinuous();
        }
        else
        {
            UpdateDiscrete();
        }
    }

    // Update is called once per frame
    void UpdateDiscrete()
    {
        hoursTransform.localRotation =
            Quaternion.Euler(DateTime.Now.Hour * degreesPerHour, 0f, 0f);
        minutesTransform.localRotation =
            Quaternion.Euler(DateTime.Now.Minute * degreesPerMinute, 0f, 0f);
        secondsTransform.localRotation =
            Quaternion.Euler(DateTime.Now.Second * degreesPerSecond, 0f, 0f);
    }

    void UpdateContinuous()
    {
        TimeSpan time = DateTime.Now.TimeOfDay;
        hoursTransform.localRotation =
            Quaternion.Euler((float)time.TotalHours * degreesPerHour, 0f, 0f);
        minutesTransform.localRotation =
            Quaternion.Euler((float)time.TotalMinutes * degreesPerMinute, 0f, 0f);
        secondsTransform.localRotation =
            Quaternion.Euler((float)time.TotalSeconds * degreesPerSecond, 0f, 0f);
    }
}
