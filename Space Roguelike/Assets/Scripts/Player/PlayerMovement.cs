using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;
public class PlayerMovement : MonoBehaviour
{
    [SerializeField]
    private float MoveSpeed = 10;
    [SerializeField]
    private float RotationSpeed = 10;

    CharacterController characterController;

    private Quaternion RotationDirectionQuaternion;

    public enum MoveStates { None,Idle,Walking};
    public MoveStates MoveState;

    Vector2 InputDirection;

    public GameObject Mesh;

    private void Start()
    {
        characterController = GetComponent<CharacterController>();

       
    }

    public void Move (Vector2 value)
    {
        InputDirection = value;
       
        RotationDirection();
    }


    private void Update()
    {
        MoveCharacterController(InputDirection, MoveSpeed);

        if(InputDirection != Vector2.zero)
        {
            MoveState = MoveStates.Walking;
        }
        else
        {
            MoveState = MoveStates.Idle;
        }
       
    }

    void RotationDirection()
    {
        Vector3 movementForward = transform.forward * InputDirection.y;
        Vector3 movementRight = transform.right * InputDirection.x;

        Vector3 movement = movementForward + movementRight;

        if (movement != Vector3.zero)
        {
            RotationDirectionQuaternion = Quaternion.LookRotation(movement);
        }
    }

    void MoveCharacterController(Vector2 direction, float speed)
    {

        Vector3 movementForward = transform.forward * InputDirection.y;
        Vector3 movementRight = transform.right * InputDirection.x;

        Vector3 movement = movementForward + movementRight;

        movement.Normalize();


        characterController.SimpleMove(movement * speed );

       
        Mesh.transform.rotation = Quaternion.Lerp(Mesh.transform.rotation, RotationDirectionQuaternion, Time.deltaTime * RotationSpeed);
    }
}
