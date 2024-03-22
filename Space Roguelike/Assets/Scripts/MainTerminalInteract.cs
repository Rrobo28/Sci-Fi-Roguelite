using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MainTerminalInteract : InteractableObject
{
    public Animator Animator;

    bool isTableCameraActive = false;

    public override void Interact()
    {
        base.Interact();

        Animator.Play("Table");
        interactableUIManager.gameObject.SetActive(false);

        GameManager.Player.GetComponent<Player>().playerInputHandler.PlayerInput.SwitchCurrentActionMap("UI");
        isInteractable = false;
    }

    public override void Back()
    {
       base.Back();

        Animator.Play("Player");
        GameManager.Player.GetComponent<Player>().playerInputHandler.PlayerInput.SwitchCurrentActionMap("Gameplay");
        interactableUIManager.gameObject.SetActive(true);
        isInteractable = true;
    }
}
