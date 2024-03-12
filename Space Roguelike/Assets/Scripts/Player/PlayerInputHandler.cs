using System.Collections;
using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    Player player;

    PlayerInput PlayerInput;

    InputAction Movement;
    InputAction InteractPress;
    InputAction InteractHold;
    private void Awake()
    {
        player = GetComponent<Player>();

        PlayerInput = GetComponent<PlayerInput>();

        Movement = PlayerInput.currentActionMap.FindAction("Move");
        InteractPress = PlayerInput.currentActionMap.FindAction("InteractPress");
        InteractHold = PlayerInput.currentActionMap.FindAction("InteractHold");

        Movement.started += OnMove;
        Movement.performed += OnMove;
        Movement.canceled += OnMove;

        InteractPress.performed += OnInteract;
        InteractHold.performed += OnInteract;
        InteractHold.started += OnInteractStart;
        InteractHold.canceled += OnInteractionCanceled;
    }

    void OnMove(InputAction.CallbackContext context)
    {
        player.playerMovement.Move(context.ReadValue<Vector2>());
    }
    void OnInteractStart(InputAction.CallbackContext context)
    {
        player.playerInteract.InteractStarted(context);
    }

    void OnInteract(InputAction.CallbackContext context)
    {
        player.playerInteract.InteractFinished();
    }
    void OnInteractionCanceled(InputAction.CallbackContext context)
    {
        player.playerInteract.InteractionCanceled(context);
    }


}
