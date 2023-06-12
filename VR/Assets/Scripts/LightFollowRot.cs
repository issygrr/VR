using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;
using UnityEngine.XR.Interaction.Toolkit;

public class LightFollowRot : MonoBehaviour
{

  public Transform headTransform;
  public Transform controllerTransform;

    public Light areaLight;
    public float rotationDamping = 0f;
    public float rotationSpeed = 20f;

    public float rotationThreshold = 10f;
    public float rotationCooldown = 20f;


    private Quaternion initialRotation;

    private void Start()
    {
        if (headTransform == null)
            headTransform = Camera.main.transform;

        if (areaLight == null)
            areaLight = GetComponentInChildren<Light>();

        initialRotation = transform.localRotation;
    }

    private void Update()
    {
        Quaternion headRotation = InputTracking.GetLocalRotation(XRNode.Head);
        Quaternion controllerRotation = controllerTransform.localRotation;

        // Calculate the relative rotation between the head and controller
        Quaternion relativeRotation = Quaternion.Inverse(headRotation) * controllerRotation;

        // Check if the angle of the relative rotation is above the threshold
        float relativeAngle = Quaternion.Angle(Quaternion.identity, relativeRotation);
        if (relativeAngle > rotationThreshold)
        {
            // Apply the relative rotation to the initial rotation of the light with damping and speed
            Quaternion newRotation = Quaternion.Slerp(transform.localRotation, relativeRotation * initialRotation, rotationDamping * Time.deltaTime * rotationSpeed);

            // Apply the new rotation to the light
            transform.localRotation = newRotation;
        }
        else
        {
            // Reset the rotation of the light to its initial rotation
            transform.localRotation = initialRotation;
        }
    }
}




