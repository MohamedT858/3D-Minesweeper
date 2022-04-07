using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MovementController : MonoBehaviour
{   
   
    public CharacterController controllerComponent;
    public float moveSpeed = 10;
    public float gravity = -9.81f;
    public float JumpH = 2;
    Vector3 velocity;
    bool isTouchingGround;

    public Transform GroundCheck;
    public float groundDistance = .4f;
    public LayerMask groundMask;
    

    void Start()
    {
        controllerComponent = GetComponent<CharacterController>();
        
       
    }     
    void Update()
    {
        isTouchingGround = Physics.CheckSphere(GroundCheck.position, groundDistance, groundMask);

        if (isTouchingGround && velocity.y < 0)
        {
            velocity.y = -2f;
        }

        float horizontalInput = Input.GetAxis("Horizontal");


        float verticalInput = Input.GetAxis("Vertical");

        Vector3 MovementVec = transform.right * horizontalInput + transform.forward * verticalInput;
        controllerComponent.Move(MovementVec * moveSpeed * Time.deltaTime);

        velocity.y += gravity * Time.deltaTime;
        controllerComponent.Move(velocity * Time.deltaTime);

        if (Input.GetKey(KeyCode.Space) && isTouchingGround)
        {
            velocity.y = Mathf.Sqrt(JumpH * -2f * gravity);
        }


    }
}
