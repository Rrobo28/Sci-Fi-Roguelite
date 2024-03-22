using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{

    Rigidbody rigidbody;
    void Start()
    {
        rigidbody = GetComponent<Rigidbody>();

        rigidbody.AddForce(GameManager.Player.GetComponent<Player>().Mesh.transform.forward* 50, ForceMode.Impulse);

       
    }

   
}
