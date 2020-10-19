using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class playerController : MonoBehaviour
{

    public float walkSpeed;

    Rigidbody rb;
    Vector3 moveDirection;


    void Awake()
    {
        rb = GetComponent<Rigidbody>();  //Sets rb to the player rigid body
    }


    void Update() //called every frame
    {
        //Gets directional input from user
        float horizontalMovement = Input.GetAxisRaw("Horizontal");
        float verticalMovement = Input.GetAxisRaw("Vertical");

        //combines input and stores in vector3, normalize fixes diagnol speed 
        moveDirection = (horizontalMovement * transform.right + verticalMovement * transform.forward).normalized;
    }

    void FixedUpdate() //called every physics step
    {
        Move();
    }

    void Move()
    {
        //yVelFix applys velocity on Y axis so pickle doesn't fall slow += yVelFix sets
        Vector3 yVelFix = new Vector3(0, rb.velocity.y, 0);
        
        //velocity is a Vector3, Time.deltaTime gives us time units
        rb.velocity = moveDirection * walkSpeed * Time.deltaTime;

        rb.velocity += yVelFix;
    }
}
