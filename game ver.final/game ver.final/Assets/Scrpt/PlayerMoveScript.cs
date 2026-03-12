//担当：木村

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerMoveScript : MonoBehaviour
{
    public float speed = 5.0f; // 前進の速度
    public float rotationSpeed = 500.0f; // 回転の速度

    GameObject Camera;
    public GameObject enemy;
    ChaseController enemyBool;

    float vertical;
    float horizontal;


    private CharacterController con;
    private Vector3 Jump_velocity;

    public float jump = 2.0f; //ジャンプの高さ
    public float gravity = -40f;　//重力

    void Start()
    {
        Camera = GameObject.Find("MainCamera");

        enemy = GameObject.Find("Enemy");
        enemyBool = enemy.GetComponent<ChaseController>();
        con=GetComponent<CharacterController>();


    }

    void Update()
    {
        vertical = Input.GetAxis("Vertical");
        horizontal = Input.GetAxis("Horizontal");

        if (enemyBool.Enemy==false)
        {  //ジャンプ判定
            if (con.isGrounded && Jump_velocity.y < 0)
            {
                Jump_velocity.y = -2.0f;
            }

            if (Input.GetButtonDown("Jump") && con.isGrounded)
            {
                Debug.Log("jump");
                //ジャンプ時の効果音
                GetComponent<AudioSource>().Play();
                Jump_velocity.y = Mathf.Sqrt(jump * -2.0f * gravity);
            }

            Jump_velocity.y += gravity * Time.deltaTime;
        }
    }

    void FixedUpdate()
    {
        Vector3 cameraForward = Vector3.Scale(Camera.transform.forward, new Vector3(1, 0, 1)).normalized;

        Vector3 moveForward = cameraForward * vertical + Camera.transform.right * horizontal;

        con.Move(moveForward * speed); //移動
        con.Move(Jump_velocity * Time.deltaTime); //ジャンプ

        if (moveForward != Vector3.zero)
        {
            transform.rotation = Quaternion.LookRotation(moveForward);
        }
    }

}

