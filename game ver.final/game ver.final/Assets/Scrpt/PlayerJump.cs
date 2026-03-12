//担当：木村

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.EventSystems;

public class PlayerJump : MonoBehaviour
{
    CharacterController con;

    float moveVelocityY;

    public float jumpPower = 6;

    public GameObject Enemy;
    ChaseController ChaseCon;
    // Start is called before the first frame update
    void Start()
    {
        con = GetComponent<CharacterController>();
        ChaseCon = Enemy.GetComponent<ChaseController>();
    }

    // Update is called once per frame
    void Update()
    {
        moveVelocityY += Physics.gravity.y * Time.deltaTime * 2;

        //ジャンプ
        if (con.isGrounded)
        {

            moveVelocityY = -0.5f;

            if (Input.GetButtonDown("Jump"))
            {//ジャンプ時の効果音
                GetComponent<AudioSource>().Play();
                moveVelocityY = jumpPower;
            }
        }

        con.Move(new Vector3(0, moveVelocityY, 0) * Time.deltaTime);
    }
}
