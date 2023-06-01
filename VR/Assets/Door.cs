using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Door : MonoBehaviour
{
    public float openAngle = 90f;
    public float openSpeed = 5f;

    private Quaternion initialRot;
    private Quaternion targetRot;
    public bool isOpen = false;
    void Start()
    {
        initialRot = transform.rotation;
        targetRot = Quaternion.Euler(transform.eulerAngles + new Vector3(0f, openAngle, 0f));
    }

    // Update is called once per frame
    void Update()
    {
        if (isOpen)
        {
            //open door
            transform.rotation = Quaternion.Lerp(transform.rotation, targetRot, openSpeed * Time.deltaTime);
        }
        else
        {
            //close door
            transform.rotation = Quaternion.Lerp(transform.rotation, initialRot, openSpeed * Time.deltaTime);
        }
               
    }
    public void Open()
    {
        isOpen = true;
    }
}
