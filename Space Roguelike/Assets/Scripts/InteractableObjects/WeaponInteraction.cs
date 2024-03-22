using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class WeaponInteraction : InteractableObject
{
    [Header("Gun Stats")]
    public Weapon Weapon;
    private Color HighlightColour;


    public override void Interact()
    {
        if (!isInteractable) return;
        base.Interact();

        AttachToPlayer();
    }

    public override void Setup()
    {
        Weapon = GetComponent<Weapon>();
        SetHighlightColour();
    }

    void SetHighlightColour()
    {
        switch (Weapon.GunRarity)
        {
            case Weapon.Rarity.Common:
                HighlightColour = Color.white;
                break;
            case Weapon.Rarity.Uncommon:
                HighlightColour = Color.green;
                break;
            case Weapon.Rarity.Rate:
                HighlightColour = Color.blue;
                break;
            case Weapon.Rarity.Epic:
                Color Purple = new Color(1, 0, 1);
                HighlightColour = Purple;
                break;
            case Weapon.Rarity.Legendary:
                HighlightColour = Color.yellow;
                break;

        }
        Highlight.OutlineColor = HighlightColour;
        interactableUIManager.GetComponentInChildren<TextMeshProUGUI>().color = HighlightColour;
    }

    void AttachToPlayer()
    {
        GetComponent<MeshCollider>().enabled = false;
        GetComponent<Rigidbody>().isKinematic = true;

        interactableUIManager.HideInteractUI();
        interactableUIManager.gameObject.SetActive(false);

        GameManager.Player.GetComponent<Player>().playerInteract.PickUpWeapon(Weapon);

        isInteractable = false;
    }
}
