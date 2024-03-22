using UnityEditor.Timeline.Actions;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerInputHandler : MonoBehaviour
{
    Player player;

    public PlayerInput PlayerInput;

    InputAction Movement;
    InputAction InteractPress;
    InputAction InteractHold;
    InputAction SwapWeapon;
    InputAction AttackAction;

    InputAction BackAction;

    InputActionMap UIMap;


    private void Awake()
    {
        
    
        player = GetComponent<Player>();

        PlayerInput = GetComponent<PlayerInput>();
        PlayerInput.SwitchCurrentActionMap("Gameplay");

        Movement = PlayerInput.currentActionMap.FindAction("Move");
        InteractPress = PlayerInput.currentActionMap.FindAction("InteractPress");
        InteractHold = PlayerInput.currentActionMap.FindAction("InteractHold");
        SwapWeapon = PlayerInput.currentActionMap.FindAction("SwapWeapon");
        AttackAction = PlayerInput.currentActionMap.FindAction("Attack");
       

        Movement.started += OnMove;
        Movement.performed += OnMove;
        Movement.canceled += OnMove;

        SwapWeapon.performed += SwapWeaponPressed;

        InteractPress.performed += OnInteract;
        InteractHold.performed += OnInteract;
        InteractHold.started += OnInteractStart;
        InteractHold.canceled += OnInteractionCanceled;
       

        AttackAction.performed += AttackPressed;
        AttackAction.canceled += AttackCancelled;


        PlayerInput.SwitchCurrentActionMap("UI");

        BackAction = PlayerInput.currentActionMap.FindAction("Back");

        BackAction.performed += Back;

        PlayerInput.SwitchCurrentActionMap("Gameplay");
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

    void SwapWeaponPressed(InputAction.CallbackContext context)
    {
        player.playerWeaponHandler.SwapWeapon(context);
    }
    void AttackPressed(InputAction.CallbackContext context)
    {
        player.playerAttack.AttackPressed();
    }
    void AttackCancelled(InputAction.CallbackContext context)
    {
        player.playerAttack.AttackCancelled();
    }
    void Back(InputAction.CallbackContext context)
    {
        player.playerInteract.Back();
    }

    private void OnDisable()
    {
        Movement.started -= OnMove;
        Movement.performed -= OnMove;
        Movement.canceled -= OnMove;

        InteractPress.performed -= OnInteract;
        InteractHold.performed -= OnInteract;
        InteractHold.started -= OnInteractStart;
        InteractHold.canceled -= OnInteractionCanceled;

        SwapWeapon.performed -= SwapWeaponPressed;

        AttackAction.performed -= AttackPressed;
        AttackAction.canceled -= AttackCancelled;

        BackAction.performed -= Back;
    }


}
