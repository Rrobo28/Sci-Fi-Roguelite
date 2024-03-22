using System.Collections;
using System.Collections.Generic;
using UnityEditor;
using UnityEngine;
using UnityEngine.InputSystem;

public class PlayerWeaponHandler : MonoBehaviour
{

    public GameObject hand;
    public GameObject pistolHand;
    public GameObject meleeHand;
    private Player player;

    private int WeaponNumber = -1;

    public Weapon CurrentWeaponEquipped;

    private void Awake()
    {
       player = GetComponent<Player>();
    }
    public void AttachWeaponToHand(Weapon weaponToAttach)
    {
        switch (weaponToAttach.type)
        {
            case Weapon.WeaponType.Primary:
               
                weaponToAttach.transform.parent.SetParent(hand.transform);
                player.playerInventory.SetPrimaryWeapon(weaponToAttach);
                if (!CurrentWeaponEquipped || CurrentWeaponEquipped.type == Weapon.WeaponType.Primary)
                {
                    CurrentWeaponEquipped = weaponToAttach;
                    WeaponNumber = 0;
                    player.playerAnimation.WeaponTypeChanged();
                    player.playerHUD.UpdateAmmoText(CurrentWeaponEquipped.ReserveAmmo, CurrentWeaponEquipped.AmmoInMag);
                }
                else
                {
                    weaponToAttach.transform.parent.gameObject.SetActive(false);
                }
               
                break;
            case Weapon.WeaponType.Secondary:
               
                weaponToAttach.transform.parent.SetParent(pistolHand.transform);
                player.playerInventory.SetSecondaryWeapon(weaponToAttach);
                if(!CurrentWeaponEquipped || CurrentWeaponEquipped.type == Weapon.WeaponType.Secondary)
                {
                    CurrentWeaponEquipped = weaponToAttach;
                    WeaponNumber = 1;
                    player.playerAnimation.WeaponTypeChanged();
                    player.playerHUD.UpdateAmmoText(CurrentWeaponEquipped.ReserveAmmo, CurrentWeaponEquipped.AmmoInMag);
                }
                else
                {
                    weaponToAttach.transform.parent.gameObject.SetActive(false);
                }
                break;
            case Weapon.WeaponType.Melee:
                weaponToAttach.transform.parent.SetParent(meleeHand.transform);
                player.playerInventory.SetMeleeWeapon(weaponToAttach);
                if (!CurrentWeaponEquipped || CurrentWeaponEquipped.type == Weapon.WeaponType.Melee)
                {
                    CurrentWeaponEquipped = weaponToAttach;
                    WeaponNumber = 2;
                    player.playerAnimation.WeaponTypeChanged();
                    player.playerHUD.UpdateAmmoText(CurrentWeaponEquipped.ReserveAmmo, CurrentWeaponEquipped.AmmoInMag);
                }
                else
                {
                    weaponToAttach.transform.parent.gameObject.SetActive(false);
                }
                break;

        }

        weaponToAttach.transform.parent.localPosition = Vector3.zero;
        weaponToAttach.transform.parent.localRotation = Quaternion.Euler(0, 0, 0);

        weaponToAttach.transform.localPosition = Vector3.zero;
        weaponToAttach.transform.localRotation = Quaternion.Euler(0, 0, 0);
    }

    public void SwapWeapon(InputAction.CallbackContext context)
    {

        int count = 0;
        foreach(Weapon w in player.playerInventory.Weapons)
        {
            if (w != null)
            {
                count++;
            }
        }

        if (count < 2) return;
        CurrentWeaponEquipped.transform.parent.gameObject.SetActive(false);
        if (WeaponNumber == 2)
        {
            WeaponNumber = 0;
        }
        else
        {
            WeaponNumber++;
        }
        if(player.playerInventory.Weapons[WeaponNumber] != null)
        {
            CurrentWeaponEquipped = player.playerInventory.Weapons[WeaponNumber];
            
        }
        else
        {
            if (WeaponNumber == 2)
            {
                WeaponNumber = 0;
            }
            else
            {
                WeaponNumber++;
            }
            CurrentWeaponEquipped = player.playerInventory.Weapons[WeaponNumber];
           
        }
        CurrentWeaponEquipped.transform.parent.gameObject.SetActive(true);
        player.playerHUD.UpdateAmmoText(CurrentWeaponEquipped.ReserveAmmo, CurrentWeaponEquipped.AmmoInMag);
        player.playerAnimation.WeaponTypeChanged();
    }
}

