using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;
using UnityEngine.InputSystem;
using System;
public class InteractableObject : MonoBehaviour
{
    public Canvas InteractionPopup;

    public TextMeshProUGUI textMeshProUGUI;

    private bool PlayerIsInRange;

    public PlayerInput playerInput;

    public enum InteractionType {OnCollision,Press,Hold}

    public InteractionType interactionType;

    private void Awake()
    {
        //playerInput = GameObject.FindGameObjectWithTag("Player").GetComponent<PlayerInput>().actions;
    }

    private void OnTriggerEnter(Collider other)
    {
        if(other.CompareTag("Player"))
        {

            if(interactionType != InteractionType.OnCollision)
            {
                ShowInteractUI();
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
        if (other.CompareTag("Player"))
        {
            if (interactionType != InteractionType.OnCollision)
            {
                HideInteractUI();
            }
            else
            {
                Interact();
            }
            PlayerIsInRange = false;
        }
    }

    void ShowInteractUI()
    {
        InteractionPopup.gameObject.SetActive(true);
    }
    void HideInteractUI()
    {
        InteractionPopup.gameObject.SetActive(false);
    }

    public virtual void Interact()
    {

    }
}
