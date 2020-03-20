using UnityEngine;
using System.Collections;
using System;
// Attach this script to the camera that you want to follow the target
public class ArrowDirection : MonoBehaviour
{
    public Quaternion targetRot;        // The rotation of the device camera from Frame.Pose.rotation
    public GameObject arrow;            // The direction indicator on the person indicator
    private float rotationSmoothingSpeed = 0.0f;

    void LateUpdate()
    {
        //arrow = GameObject.Find("Arrow(Clone)");
        Vector3 targetEulerAngles = targetRot.eulerAngles;
        float rotationToApplyAroundY = targetEulerAngles.y;
        float newCamRotAngleY = Mathf.LerpAngle(transform.eulerAngles.y, rotationToApplyAroundY, rotationSmoothingSpeed * Time.deltaTime);
        Quaternion newCamRotYQuat = Quaternion.Euler(0, newCamRotAngleY, 0);
        arrow.transform.rotation = newCamRotYQuat;
    }
}