using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Rendering;

public class Player : MonoBehaviour
{
    public PlayerMovement playerMovement;
    public PlayerAnimation playerAnimation;
    public PlayerInteract playerInteract;
    private void Awake()
    {
        playerMovement = GetComponent<PlayerMovement>();
        playerAnimation = GetComponent<PlayerAnimation>();
        playerInteract = GetComponent<PlayerInteract>();
    }

    void OnControlsChanged()
    {
        Debug.Log("ControlsChanged");
    }
}
