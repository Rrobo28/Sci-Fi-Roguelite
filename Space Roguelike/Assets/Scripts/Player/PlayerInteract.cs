using System.Collections;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.InputSystem;
using UnityEngine.InputSystem.Interactions;

public class PlayerInteract : MonoBehaviour
{
    InteractableObject ObjectToInteractWith;
   

    private Player player;

    private void Awake()
    {
        player = GetComponent<Player>();
    }

    public void InteractionCanceled(InputAction.CallbackContext context)
    {
        if (ObjectToInteractWith != null )
        {
            if (context.interaction is HoldInteraction)
            {
                ObjectToInteractWith.InteractionCancelled(context);
                Debug.Log("CANCELED");
            }
        }
       
        
    }
    public void InteractStarted(InputAction.CallbackContext context)
    {
       if (ObjectToInteractWith != null &&ObjectToInteractWith.interactionType == InteractableObject.InteractionType.Hold && ObjectToInteractWith.isInteractable) 
       {
            if (context.interaction is HoldInteraction)
            {
                ObjectToInteractWith.InteractStarted(context);
                Debug.Log("STARTED");
            }
        }
      

    }
    public void InteractFinished()
    {
        if(ObjectToInteractWith != null && ObjectToInteractWith.isInteractable)
        {
            ObjectToInteractWith.InteractFinished();
            Debug.Log("FINISHED");
        }
       
    }

    public void Back()
    {
        if (ObjectToInteractWith != null  && ObjectToInteractWith.MenuInteraction)
        {
            ObjectToInteractWith.Back();
            
        }
    }


    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("InteractableObject"))
        {
            ObjectToInteractWith = other.gameObject.GetComponent<InteractableObject>();
        }
    }
    private void OnTriggerExit(Collider other)
    {
        if (other.CompareTag("InteractableObject"))
        {
            ObjectToInteractWith = null;
        }
    }

    public void PickUpWeapon(Weapon weaponToAttach)
    {
        player.playerWeaponHandler.AttachWeaponToHand(weaponToAttach);

    }


}
