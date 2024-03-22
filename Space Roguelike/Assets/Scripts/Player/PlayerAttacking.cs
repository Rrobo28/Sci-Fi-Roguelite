using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerAttacking : MonoBehaviour
{
    Player player;

    bool AttackHeld = false;
    bool ReloadStarted = false;

    Weapon CurrentWeapon;

    float lastAttackTime = 0;
    float reloadStartTime = 0;

    private void Awake()
    {
        player = GetComponent<Player>();
    }
    public void AttackPressed()
    {
        if (!player.playerWeaponHandler.CurrentWeaponEquipped) return;

        CurrentWeapon = player.playerWeaponHandler.CurrentWeaponEquipped;

        if(CurrentWeapon.fireMode == Weapon.FireMode.Single)
        {
            Attack();
        }

        AttackHeld = true;
    }

    public void AttackCancelled()
    {
        lastAttackTime =0;
        AttackHeld = false;
    }

    private void Update()
    {

       // Debug.DrawLine(CurrentWeapon.bulletSpawn.transform.position, player.Mesh.transform.forward * 100000, Color.red);

        if (AttackHeld)
        {
            if(Time.time >= (60 / CurrentWeapon.RateOfFire ) + lastAttackTime)
            {
                Attack();
            }
        }
        if(ReloadStarted)
        {
            if (Time.time >= reloadStartTime + CurrentWeapon.ReloadTime)
            {
                Reload();
            }
        }
    }


    void Attack()
    {
        if(CurrentWeapon.type == Weapon.WeaponType.Primary || CurrentWeapon.type == Weapon.WeaponType.Secondary)
        {
            if (CurrentWeapon.AmmoInMag > 0 && !ReloadStarted)
            {
                Instantiate(CurrentWeapon.bullet, CurrentWeapon.bulletSpawn.transform.position, CurrentWeapon.bulletSpawn.transform.rotation);
                lastAttackTime = Time.time;
                CurrentWeapon.AmmoInMag--;
                player.playerHUD.UpdateAmmoText(CurrentWeapon.ReserveAmmo, CurrentWeapon.AmmoInMag);
            }
            else if(!ReloadStarted)
            {
                StartReload();
            }
            
        }
    }

   void StartReload()
    {
        reloadStartTime = Time.time;
        ReloadStarted = true;
    }

    void Reload()
    {
        int missingRounds = CurrentWeapon.MagSize - CurrentWeapon.AmmoInMag;

        if (CurrentWeapon.ReserveAmmo >= missingRounds)
        {
            CurrentWeapon.AmmoInMag = CurrentWeapon.MagSize;
            CurrentWeapon.ReserveAmmo -= missingRounds;
        }
        else
        {
            CurrentWeapon.AmmoInMag = CurrentWeapon.ReserveAmmo;
            CurrentWeapon.ReserveAmmo = 0;
        }
        reloadStartTime = 0;
        ReloadStarted = false;
        player.playerHUD.UpdateAmmoText(CurrentWeapon.ReserveAmmo, CurrentWeapon.AmmoInMag);
    }
}
