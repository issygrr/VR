using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class DoorSwitch1 : MonoBehaviour
{
    public bool isActivated { get; private set; }

    private bool isInteractable = true;
   

    private void OnTriggerEnter(Collider other)
    {
        if (isInteractable && other.CompareTag("Controller")) 
        {
            isActivated = true;
        }
        
    }
    private void OnTriggerExit(Collider other)
    {
        if (isInteractable && other.CompareTag("Controller"))
        {
            isActivated = false;
        }

    }
    public void SetInteractable(bool interactable)
    {
        isInteractable = interactable;
    }

    public void Activate()
    {
        isActivated = true;
        
    }
    public void OpenDoor(GameObject door)
    {
        Door doorComponent = door.GetComponent<Door>();
        doorComponent.Open();
    }
    void Start()
    {
        
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
