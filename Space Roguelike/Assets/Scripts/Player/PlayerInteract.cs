using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

public class PlayerInteract : MonoBehaviour
{
    GameObject ObjectToInteractWith;

    public float HoldDuration = 0;

    public float HoldStartTime = 0;

    float HoldTime;


    public void InteractionCanceled(InputAction.CallbackContext context)
    {
        HoldStartTime = 0;
        HoldDuration = 0;

        ObjectToInteractWith.GetComponentInChildren<InteractableUIManager>().HideHoldIndicator();
    }
    public void InteractStarted(InputAction.CallbackContext context)
    {
       if (ObjectToInteractWith == null ||ObjectToInteractWith.GetComponent<InteractableObject>().interactionType != InteractableObject.InteractionType.Hold) 
       {
           return;
       }
       else if(context.interaction is HoldInteraction)
       {
            HoldInteraction holdInteraction = (HoldInteraction)context.interaction;

            HoldDuration = holdInteraction.duration;
            HoldStartTime = Time.time;

            ObjectToInteractWith.GetComponentInChildren<InteractableUIManager>().ShowHoldIndicator(HoldStartTime,HoldDuration);


        }

    }
    public void InteractFinished()
    {
        if(ObjectToInteractWith == null)
        {
            return;
        }

        else if (ObjectToInteractWith.GetComponent<InteractableObject>().interactionType == InteractableObject.InteractionType.Press)
        {
            Interact();
        }
        else if (ObjectToInteractWith.GetComponent<InteractableObject>().interactionType == InteractableObject.InteractionType.Hold)
        {
            if(HoldStartTime !=0 && (Time.time > HoldStartTime + HoldDuration)) 
            {
                Interact();
                HoldStartTime = 0;
                HoldDuration = 0;
                ObjectToInteractWith.GetComponentInChildren<InteractableUIManager>().HideHoldIndicator();
            }
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("InteractableObject"))
        {
            HoldStartTime = 0;
            HoldDuration = 0;
            ObjectToInteractWith = other.gameObject;
            Debug.Log("Pressed");
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("InteractableObject"))
        {
            HoldStartTime = 0;
            HoldDuration = 0;
            ObjectToInteractWith = null;
        }
    }

    void Interact()
    {
        if (ObjectToInteractWith)
        {
            ObjectToInteractWith.GetComponent<InteractableObject>().Interact();
        }
       
    }


}
