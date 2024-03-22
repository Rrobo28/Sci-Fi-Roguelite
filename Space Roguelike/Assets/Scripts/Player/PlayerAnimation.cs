using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Animations;
using UnityEngine.Animations.Rigging;

public class PlayerAnimation : MonoBehaviour
{
    Animator animator;

    Player player;

    public TwoBoneIKConstraint twoBoneIKConstraint;
    public RigBuilder rigBuilder;

    private void Start()
    {
        animator = GetComponent<Animator>();
        player = GetComponent<Player>();
    }

    private void Update()
    {
        animator.SetInteger("MoveState", (int)player.playerMovement.MoveState);
    }

    public void WeaponTypeChanged()
    {
        if(player.playerWeaponHandler.CurrentWeaponEquipped)
      
        switch (player.playerWeaponHandler.CurrentWeaponEquipped.type)
            {
                case Weapon.WeaponType.Primary:
                    animator.SetInteger("WeaponType", 1);
                    animator.SetLayerWeight(1, 1);
                    animator.SetLayerWeight(0, 0);
                    animator.SetLayerWeight(2, 0);
                    animator.SetLayerWeight(3, 0);
                    twoBoneIKConstraint.data.target = player.playerWeaponHandler.CurrentWeaponEquipped.HandIKTarget.transform;
                    twoBoneIKConstraint.data.hint = player.playerWeaponHandler.CurrentWeaponEquipped.HandIKTarget.transform;
                    break;
                case Weapon.WeaponType.Secondary:
                    animator.SetInteger("WeaponType", 2);
                    animator.SetLayerWeight(1, 0);
                    animator.SetLayerWeight(0, 0);
                    animator.SetLayerWeight(2, 1);
                    animator.SetLayerWeight(3, 0);
                    twoBoneIKConstraint.data.target = null;
                    twoBoneIKConstraint.data.hint = null;
                    break;
                case Weapon.WeaponType.Melee:
                    animator.SetInteger("WeaponType", 3);
                    animator.SetLayerWeight(1, 0);
                    animator.SetLayerWeight(0, 0);
                    animator.SetLayerWeight(2, 0);
                    animator.SetLayerWeight(3, 1);
                    twoBoneIKConstraint.data.target = null;
                    twoBoneIKConstraint.data.hint = null;
                    break;
            }
        
       
        rigBuilder.Build();
        


    }
}
