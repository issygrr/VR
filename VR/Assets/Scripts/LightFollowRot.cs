using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR;

public class LightFollowRot : MonoBehaviour
{

  public Transform headTransform;
  public Transform controllerTransform;
   // public string thumbstickHorizontalAxis = "ThumbstickHorizontal";
   // public string thumbstickVerticalAxis = "ThumbstickVertical";
    public float rotationSpeed = 1f;
    private Quaternion initialHeadRotation;
    private Quaternion initialControlRotation;
    private Light areaLight;

    private void Start()
    {
        areaLight = GetComponentInChildren<Light>();
        initialHeadRotation = headTransform.rotation;
        initialControlRotation = controllerTransform.rotation;
    }

    private void Update()
    {
        Quaternion headRotation = headTransform.rotation * Quaternion.Inverse(initialHeadRotation);
        //Quaternion headRotation = InputTracking.GetLocalRotation(XRNode.Head);

        // float thumbstickHorizontalInput = Input.GetAxis(thumbstickHorizontalAxis);
        // float thumbstickVerticalInput = Input.GetAxis(thumbstickVerticalAxis);

        Quaternion thumbstickRotation = controllerTransform.rotation * Quaternion.Inverse(initialControlRotation); ; //Quaternion.Euler(thumbstickVerticalInput, thumbstickHorizontalInput, 0f);
        Quaternion combinedRotation = headRotation * thumbstickRotation;

        transform.rotation = Quaternion.RotateTowards(transform.rotation, combinedRotation, 0.2f);
    }
    //  private Light areaLight;
    //// Start is called before the first frame update
    //  void Start()
    //  {
    //    areaLight = GetComponentInChildren<Light>();
    //  }

    //// Update is called once per frame
    // private void Update()
    //  {
    //    Quaternion headRotation = InputTracking.GetLocalRotation(XRNode.Head);
    //    Quaternion controllerRotation = controllerTransform.localRotation;

    //    Quaternion combinedRotation = headRotation * controllerRotation;

    //    transform.rotation = combinedRotation;
    //  }
}


