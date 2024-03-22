using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class PlayerHUD : MonoBehaviour
{
    public TextMeshProUGUI AmmoText;


    public void UpdateAmmoText(int totalAmmo,int ammoInMag)
    {
        AmmoText.text = ammoInMag + " / " + totalAmmo;
    }
  
}
