using UnityEngine;

public class Player : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public PlayerAnimation playerAnimation;
    public PlayerInteract playerInteract;
    public PlayerInventory playerInventory;
    public PlayerWeaponHandler playerWeaponHandler;
    public PlayerUI playerUI;
    public PlayerAttacking playerAttack;
    public PlayerHUD playerHUD;
    public PlayerInputHandler playerInputHandler;

    public GameObject Mesh;
    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        playerAnimation = GetComponent<PlayerAnimation>();
        playerInteract = GetComponent<PlayerInteract>();
        playerInventory = GetComponent<PlayerInventory>();
        playerWeaponHandler = GetComponent<PlayerWeaponHandler>();
        playerUI = GetComponent<PlayerUI>();
        playerAttack = GetComponent<PlayerAttacking>();
        playerHUD = GetComponent<PlayerHUD>();
        playerInputHandler = GetComponent<PlayerInputHandler>();
    }


}
