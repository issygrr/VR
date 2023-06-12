using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PickUp : XRGrabInteractable
{
    public int points = 1; //points awarded for picking up object
    

    public void Onselected()
    {
        //isPickedUp = true;
        ScoreManager.Instance.AddPoints(points);
        Rigidbody rb = GetComponent<Rigidbody>();

        if (rb != null)
        {
            rb.isKinematic = true;
            rb.useGravity = false;
        }
    }
    public void OnReleased()
    {
        gameObject.SetActive(false);
    }
   


}
