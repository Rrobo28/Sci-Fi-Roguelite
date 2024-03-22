using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
using System;
using UnityEngine.InputSystem.Interactions;
public class InteractableObject : MonoBehaviour
{
    [Header ("Interaction")]
    public InteractionType interactionType;
    public bool hasHighlight = false;

    [HideInInspector]
    public float HoldDuration = 0;
    [HideInInspector]
    public float HoldStartTime = 0;
    

    [Header ("UI")]
    public InteractableUIManager interactableUIManager;
    public bool MenuInteraction = true;
    public bool isInteractable = true;
    private bool PlayerIsInRange;

    [HideInInspector]
    public Outline Highlight;
    public enum InteractionType {OnCollision,Press,Hold}

    private void Start()
    {
        if(GetComponent<Outline>() != null)
        {
            Highlight = GetComponent<Outline>();
        }
        Debug.Log("Running");
        interactableUIManager.gameObject.SetActive(false);

        Setup();
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player") && isInteractable)
        {

            if(interactionType != InteractionType.OnCollision)
            {
                interactableUIManager.gameObject.SetActive(true);
                interactableUIManager.ShowInteractUI();
            }
            else
            {
                Interact();
            }
            PlayerIsInRange = true;

        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("Player") && isInteractable)
        {
            if (interactionType != InteractionType.OnCollision)
            {
                interactableUIManager.HideInteractUI();
                interactableUIManager.gameObject.SetActive(false);
                
            }
            else
            {
                Interact();
            }
            PlayerIsInRange = false;
        }
    }

    public virtual void Back()
    {

    }

    public void InteractStarted(InputAction.CallbackContext context)
    {
        if (interactionType == InteractionType.Hold)
        {
            HoldInteraction holdInteraction = (HoldInteraction)context.interaction;

            HoldDuration = holdInteraction.duration;
            HoldStartTime = Time.time;

            interactableUIManager.ShowHoldIndicator();

            Debug.Log("SHOW HOLD INDICATOR");
        }
    }
    public void InteractionCancelled(InputAction.CallbackContext context)
    {
        HoldStartTime = 0;
        interactableUIManager.HideHoldIndicator();
    }

    public void InteractFinished()
    {
        if(interactionType == InteractionType.Press) 
        {
            Interact();
        }
        else if(interactionType == InteractionType.Hold) 
        {

            Debug.Log("FINISH INTERACTION :" + "TIME:"+Time.time + " START: "+ HoldStartTime + " DURATION: "+ HoldDuration);
            if (HoldStartTime != 0 )
            {
                interactableUIManager.HideHoldIndicator();
                Interact();
                HoldStartTime = 0;
            }
        }
    }

   

    public virtual void Interact()
    {

    }
    public virtual void Setup()
    {

    }
}
