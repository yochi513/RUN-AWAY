//íSìñÅFñÿë∫

using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class Camera : MonoBehaviour
{
    GameObject playerObj;
    Vector3 playerPos;

    public float rotatespeed = 100.0f;
    float angleV;

    GameObject player;

    // Start is called before the first frame update
    void Start()
    {
        playerObj = GameObject.Find("CHARACTOR");
        playerPos = playerObj.transform.position;

        player = GameObject.Find("MainCharactor");
    }

    // Update is called once per frame
    void Update()
    {
        transform.position += playerObj.transform.position - playerPos;
        playerPos = playerObj.transform.position;

        float InputH = Input.GetAxis("R_Stick_H") * rotatespeed;
        float InputV = Input.GetAxis("R_Stick_V") * rotatespeed;

        float deltaAngleV = InputV * Time.deltaTime;

        angleV += deltaAngleV;

        float clampedAngleV = Mathf.Clamp(angleV, -40, 20);

        //âÒì]êßå¿
        float overshootV = angleV - clampedAngleV; //í¥Ç¶ÇΩäpìx

        deltaAngleV -= overshootV;
        angleV = clampedAngleV;

        //â°âÒì]
        transform.RotateAround(playerPos, Vector3.up, InputH * Time.deltaTime);
        //ècâÒì]
        transform.RotateAround(playerPos, transform.right, deltaAngleV);


        //ÉJÉÅÉâÉäÉZÉbÉg
        Transform PTransform = player.transform;
        Transform CTransform = this.transform;

        Vector3 PworldAngle = PTransform.eulerAngles;
        Vector3 CworldAngle = CTransform.eulerAngles;

        float P_angle_y = PworldAngle.y;
        float C_angle_y = CworldAngle.y;

        if (Input.GetButtonDown("reset"))
        {
            Debug.Log("reset");

            float rotate_y = P_angle_y - C_angle_y; //â°âÒì]ÉäÉZÉbÉg
            float rotate_x = 0;

            if (angleV < 0)
                rotate_x = angleV;
            else if (angleV > 0)
                rotate_x = angleV;

            Debug.Log(rotate_x);

            transform.RotateAround(playerPos, Vector3.up, rotate_y);Å@//ç∂âEâÒì]
            transform.RotateAround(playerPos, player.transform.right, -rotate_x);Å@//è„â∫âÒì]

            angleV = 0;
        }
    }
}
