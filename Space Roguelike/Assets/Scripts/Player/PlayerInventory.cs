using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerInventory : MonoBehaviour
{
    public List<Weapon> Weapons = new List<Weapon>();

    private void Awake()
    {
        Weapons.Add(null);
        Weapons.Add(null);
        Weapons.Add(null);
    }

    public void SetPrimaryWeapon(Weapon weapon)
    {
        if(Weapons[0] != null)
        {
            if (!Weapons[0].transform.parent.gameObject.activeInHierarchy)
            {
                Weapons[0].transform.parent.gameObject.SetActive(true);
            }
            Weapons[0].Drop();
        }


        Weapons[0] = weapon;
       
    }
    public void SetSecondaryWeapon(Weapon weapon)
    {
        if (Weapons[1] != null)
        {
            if (!Weapons[1].transform.parent.gameObject.activeInHierarchy)
            {
                Weapons[1].transform.parent.gameObject.SetActive(true);
            }
            Weapons[1].Drop();
        }
        Weapons[1] = weapon;
    }
    public void SetMeleeWeapon(Weapon weapon)
    {
        if (Weapons[2] != null)
        {
            if (!Weapons[2].transform.parent.gameObject.activeInHierarchy)
            {
                Weapons[2].transform.parent.gameObject.SetActive(true);
            }
            Weapons[2].Drop();
        }
        Weapons[2] = weapon;
    }
}


