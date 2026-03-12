using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;


public class STAGEselectScript : MonoBehaviour
{
    // ローテーション先の座標を格納する配列
    public Vector3[] positions;
    private int currentIndex = 0;
    private Ugoki ugokiAcition;



    // ステージサムネの参照
    public Transform target;

    private void Start()
    {
        ugokiAcition=new Ugoki();
        ugokiAcition.Enable();
    }


    void Update()
    {
        // D キーで右へローテーション
        if (Input.GetKeyDown(KeyCode.D)||ugokiAcition.UI.MoveLeft.triggered)
        {
            currentIndex++;
            if (currentIndex >= positions.Length)
                currentIndex = 0; // インデックスをループさせる

            UpdatePosition();
        }

        // A キーで左へローテーション
        if (Input.GetKeyDown(KeyCode.A)||ugokiAcition.UI.MoveRight.triggered)
        {
            currentIndex--;
            if (currentIndex < 0)
                currentIndex = positions.Length - 1; // インデックスをループさせる

            UpdatePosition();
        }
    }

    void UpdatePosition()
    {
        // ターゲットの位置を更新
        target.position = positions[currentIndex];
    }
}