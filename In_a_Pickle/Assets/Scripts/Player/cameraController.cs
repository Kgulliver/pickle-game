using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class cameraController : MonoBehaviour
{
    public float minimumX = -60f;
    public float minimumY = -360f;
    public float maximumX = 60f;
    public float maximumY = 360f;

    public float sensitivityX = 15f;
    public float sensitivityY = 15f;

    public Camera cam;
    public Transform playerBody;

    private float rotationY = 0f;
    private float rotationX = 0f;


    void Update()
    {
        //camera angle increases/decreases with mouse input, scales with mouse sensitivity
        rotationX += Input.GetAxis("Mouse Y") * sensitivityX;
        rotationY += Input.GetAxis("Mouse X") * sensitivityY;

        //we use Mathf.Clamp to constrain the desired rotation values to their maximum and minimum values
        rotationX = Mathf.Clamp(rotationX, minimumX, maximumX);

        //the player rotates on the Y-axis, nothing on x, z
        transform.localEulerAngles = new Vector3(0, rotationY, 0);
        //camera needs to rtoate on both x and y, making xrotation negative is preference
        cam.transform.localEulerAngles = new Vector3(-rotationX, rotationY, 0);

        
    }

    void Start()
    {
        Cursor.lockState = CursorLockMode.Locked;

        if (Input.GetKey(KeyCode.Escape))
        {
            Cursor.lockState = CursorLockMode.None;
            Cursor.visible = true;
        }
    }


}
