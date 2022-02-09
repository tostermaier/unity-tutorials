using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SimplePlayerController : MonoBehaviour
{

    [Header("Movement")]
    private CharacterController characterController; //expected on the main game object for player
    public GameObject playerCamera;
    public float mouseSensitivity = 200f; // 200 is a good value
    public float speed = 5f; // 5 is a good value
    public float gravitiy = -9.81f;

    private float xRotation = 0f;
    private Vector3 velocity;


    // Start is called before the first frame update
    void Start()
    {
        characterController = GetComponent<CharacterController>();
    }

    // Update is called once per frame
    void Update()
    {
        Movement();
        MouseLook();
    }


    private void Movement()
    {
        float x = Input.GetAxis("Horizontal");
        float z = Input.GetAxis("Vertical");

        Vector3 move = transform.right * x + transform.forward * z;

        characterController.Move(move * speed * Time.deltaTime);
        velocity.y += gravitiy * Time.deltaTime;
        characterController.Move(velocity * Time.deltaTime);

    }

    //Handle mouse look
    private void MouseLook()
    {
        float mouseX = Input.GetAxis("Mouse X") * mouseSensitivity * Time.deltaTime;
        float mouseY = Input.GetAxis("Mouse Y") * mouseSensitivity * Time.deltaTime;
       
        xRotation -= mouseY;
        xRotation = Mathf.Clamp(xRotation, -90f, 90f);

        playerCamera.transform.localRotation = Quaternion.Euler(xRotation, 0f, 0f);
        transform.Rotate(Vector3.up * mouseX);
    }

}
