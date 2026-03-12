using System.Collections;
using System.Collections.Generic;
using UnityEngine;

    //担当：木村


public class Playermove2 : MonoBehaviour
{

    public float speed = 5.0f; // 前進の速度
    public float rotationSpeed = 500.0f; // 回転の速度

    private CharacterController characterController;
    private Rigidbody rb;

    GameObject Camera;

    float vertical;
    float horizontal;

    void Start()
    {
        characterController = GetComponent<CharacterController>();
        Camera = GameObject.Find("MainCamera");

        rb = GetComponent<Rigidbody>();
    }

    void Update()
    {
        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");
    }

    void FixedUpdate()
    {
        Vector3 cameraForward = Vector3.Scale(Camera.transform.forward, new Vector3(1, 0, 1)).normalized;

        Vector3 moveForward = cameraForward * vertical + Camera.transform.right * horizontal;

        rb.velocity = moveForward * speed + new Vector3(0, rb.velocity.y, 0);

        if (moveForward != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(moveForward);
        }
    }

}
