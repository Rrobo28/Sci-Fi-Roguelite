using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
public class DoorInteraction : InteractableObject
{
    [Header("Door Reference")]
    public GameObject Door;

    bool IsOpen = false;

    float DoorOpenX = 3f;

    Vector3 DoorOpenPosition;
    Vector3 DoorShutPosition;
    public float DoorOpenSpeed = 10;

    public override void Setup()
    {
        DoorShutPosition = Door.transform.position;
        DoorOpenPosition = new Vector3(Door.transform.position.x , Door.transform.position.y - DoorOpenX, Door.transform.position.z);
    }

    public override void Interact()
    {
         if (!isInteractable) return;

        base.Interact();
        ToggleDoor();
    }

    private void Update()
    {
        if (IsOpen && Door.transform.position != DoorOpenPosition) 
        {
            Door.transform.position = Vector3.Lerp(Door.transform.position, DoorOpenPosition, Time.deltaTime * DoorOpenSpeed);
        }
        else if(!IsOpen && Door.transform.position != DoorShutPosition)
        {
            Door.transform.position = Vector3.Lerp(Door.transform.position, DoorShutPosition, Time.deltaTime * DoorOpenSpeed);
        }
    }

    void ToggleDoor()
    {
        IsOpen = !IsOpen;
    }
}
