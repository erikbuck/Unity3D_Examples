using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using System;  // For DateTime


public class RobotArmControl : MonoBehaviour {
    public Rigidbody thingPrefab;
    public float baseRotationDeg;
    public float partARotationDeg;
    public float partBRotationDeg;
    public float clawRotationDeg;

    Transform baseTransform, partATransform, partBTransform, clawTransform;
    float baseTargetRotationDeg = 45.0f;
    float partATargetRotationDeg = 15.0f;
    float partBTargetRotationDeg = 30.0f;
    float clawTargetRotationDeg = 45.0f;
    float percent = 0.0f;

    void Awake()
    {
        baseTransform = this.transform.Find("Base");
        partATransform = baseTransform.transform.Find("PartA");
        partBTransform = partATransform.transform.Find("PartB");
        clawTransform = partBTransform.transform.Find("PartClaw");
    }

    // Use this for initialization
    void Start () {
        float baseTargetRotationDeg;
        float partATargetRotationDeg;
        float partBTargetRotationDeg;
        float clawTargetRotationDeg;
    }

    void randomizeTargets()
    {
        baseTargetRotationDeg = UnityEngine.Random.value * 180.0f - 90.0f;
        partATargetRotationDeg = UnityEngine.Random.value * 45.0f;
        partBTargetRotationDeg = UnityEngine.Random.value * 90.0f;
        clawTargetRotationDeg = UnityEngine.Random.value * 80.0f;
    }

    // Update is called once per frame
    void Update () {
        percent = Mathf.Min(1.0f, percent + 0.5f * Time.deltaTime);
        if(1.0f <= percent)
        {
            baseRotationDeg = baseTargetRotationDeg;
            partARotationDeg = partATargetRotationDeg;
            partBRotationDeg = partBTargetRotationDeg;
            clawRotationDeg = clawTargetRotationDeg;
            randomizeTargets();
            percent = 0.0f;
        }
        //float angle = Mathf.Repeat((float)DateTime.Now.TimeOfDay.TotalSeconds * 10.0f, 360.0f);
        baseTransform.localRotation = Quaternion.Euler(
            0f, 
            Mathf.Lerp(baseRotationDeg, baseTargetRotationDeg, percent), 
            0f);
        partATransform.localRotation = Quaternion.Euler(
            0f, 
            0f,
           Mathf.Lerp(partARotationDeg, partATargetRotationDeg, percent));
        partBTransform.localRotation = Quaternion.Euler(
            0f, 
            0f,
            Mathf.Lerp(partBRotationDeg, partBTargetRotationDeg, percent));
        clawTransform.localRotation = Quaternion.Euler(
            0f, 
            0f,
            Mathf.Lerp(clawRotationDeg, clawTargetRotationDeg, percent));
    }
}
