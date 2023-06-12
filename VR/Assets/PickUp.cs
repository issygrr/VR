using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.XR.Interaction.Toolkit;

public class PickUp : XRGrabInteractable
{
    public int points = 1; //points awarded for picking up object
    private bool isPickedUp = false;

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
    protected override void OnSelectEntered(SelectEnterEventArgs args)
    {
        base.OnSelectEntered(args);

        if (isPickedUp)
            return;

        isPickedUp = true;

        Rigidbody rb = GetComponent<Rigidbody>();

        if (rb != null)
        {
            rb.isKinematic = true;
            rb.useGravity = false;
        }

        ScoreManager.Instance.AddPoints(points);

        // UI stuff
    }

    protected override void OnSelectExited(SelectExitEventArgs args)
    {
        base.OnSelectExited(args);
        gameObject.SetActive(false);
        Rigidbody rb = GetComponent<Rigidbody>();
        if (rb != null)
        {
            rb.isKinematic = false;
            rb.useGravity = true;
        }
    }


}
