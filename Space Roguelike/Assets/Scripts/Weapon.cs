using UnityEngine;


public class Weapon : MonoBehaviour
{
    public enum Rarity { Common, Uncommon, Rate, Epic, Legendary };
    
    public Rarity GunRarity;
    public enum WeaponType { Melee, Primary, Secondary };
    public WeaponType type;
    public enum FireMode { Single, Burst, Auto };
    public FireMode fireMode;

    [HideInInspector]
    public int AmmoInMag;

    [Header("Ammo")]
    public int MagSize;
    public int ReserveAmmo;

    [Header("Stats")]
    public float RateOfFire;
    public float ReloadTime = 0.5f;

    [Header("Bullet")]
    public GameObject bullet;
    public GameObject bulletSpawn;

    [Header("Animations")]
    public GameObject HandIKTarget;

    private void Awake()
    {
        AmmoInMag = MagSize;
    }

    public void Drop()
    {
        transform.parent.SetParent(null);

        transform.parent.localRotation = Quaternion.Euler(0, 0, 0);
        Rigidbody rigidbody = GetComponent<Rigidbody>();

        rigidbody.isKinematic = false;
        GetComponent<MeshCollider>().enabled = true;

        rigidbody.AddForce(transform.forward * 100);

        GetComponent<WeaponInteraction>().isInteractable = true;
    }

}
