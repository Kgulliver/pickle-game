using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class FPSController : MonoBehaviour
{
    public Transform playerCamera;
    public Rigidbody rb;

    public float camRotationSpeed = 5f;
    public float cameraMinimumY = -60f;
    public float cameraMaximumY = 75f;
    public float rotationSmoothSpeed = 10f;

    public float walkSpeed = 9f;
    public float runSpeed = 14f;
    public float maxSpeed = 20f;

    public float jumpPower = 30f;

    public float extraGravity;
    public float jumpRaycastDistance;

    float bodyRotationX;
    float camRotationY;
    Vector3 directionIntentX;
    Vector3 directionIntentY;
    float speed;

    public Slider staminaSlider;
    public int staminaFallRate;
    public int staminaRegainRate;
    public int maxStamina;



    //public bool grounded;
    void Start()
    {
        staminaSlider.maxValue = maxStamina;
        staminaSlider.value = maxStamina;


    }
    void Update()
    {
        LookRotation();
        Movement();
        ExtraGravity();
        //GroundCheck();

        if (IsGrounded() && Input.GetKeyDown("space"))
        {
            Jump();
        }

        
    }

    void LookRotation()
    {
        //Cursor.visible = false;
        //Cursor.lockState = CursorLockMode.Locked;

        if (Input.GetKey(KeyCode.Escape))
        {
            Cursor.visible = true;
            Cursor.lockState = CursorLockMode.None;
        }
        else
        {
            Cursor.visible = false;
            Cursor.lockState = CursorLockMode.Locked;


            //Get camera and body rotational values
            bodyRotationX += Input.GetAxis("Mouse X") * camRotationSpeed;
            camRotationY += Input.GetAxis("Mouse Y") * camRotationSpeed;

            //stop our camera from rotation360 degrees
            camRotationY = Mathf.Clamp(camRotationY, cameraMinimumY, cameraMaximumY);

            //create rotation targets and handle rotations of the bodyt and camera
            Quaternion camTargetRotation = Quaternion.Euler(-camRotationY, 0, 0);
            Quaternion bodyTargetRotation = Quaternion.Euler(0, bodyRotationX, 0);

            //handle rotations
            transform.rotation = Quaternion.Lerp(transform.rotation, bodyTargetRotation, Time.deltaTime * rotationSmoothSpeed);

            playerCamera.localRotation = Quaternion.Lerp(playerCamera.localRotation, camTargetRotation, Time.deltaTime * rotationSmoothSpeed);
        }

    }

    void Movement()
    {
        //direction must match camera direction
        directionIntentX = playerCamera.right;
        directionIntentX.y = 0;
        directionIntentX.Normalize();

        directionIntentY = playerCamera.forward;
        directionIntentY.y = 0;
        directionIntentY.Normalize();

        //Change out characters velocity in this direction
        rb.velocity = directionIntentY * Input.GetAxis("Vertical") * speed + directionIntentX * Input.GetAxis("Horizontal") * speed + Vector3.up * rb.velocity.y;
        rb.velocity = Vector3.ClampMagnitude(rb.velocity, maxSpeed);

        //control our speed based on our movement state
        if (Input.GetKey(KeyCode.LeftShift))
        {
            if (staminaSlider.value > 0)
            {
                speed = runSpeed;
                staminaSlider.value -= Time.deltaTime  * staminaFallRate;
                
            }
            else
            {
                speed = walkSpeed;
                staminaSlider.value += Time.deltaTime * staminaRegainRate;
            }
        }
        if (!Input.GetKey(KeyCode.LeftShift))
        {
            speed = walkSpeed;
            staminaSlider.value += Time.deltaTime * staminaRegainRate;
        }
    }

    void ExtraGravity()
    {
        rb.AddForce(Vector3.down * extraGravity);
    }

    //void GroundCheck()
    //{
    //    RaycastHit groundHit;
    //    grounded = Physics.Raycast(transform.position, -transform.up, out groundHit, 1.25f);
    // }

    private bool IsGrounded()
    {
        Debug.DrawRay(transform.position, Vector3.down * jumpRaycastDistance, Color.blue);

        return Physics.Raycast(transform.position, Vector3.down, jumpRaycastDistance);
    }

    void Jump()
    {
        rb.AddForce(Vector3.up * jumpPower, ForceMode.Impulse);
    }

}

