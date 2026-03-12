using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class sentaku : MonoBehaviour
{
    public Vector3[] positions;
    private int sentcIndex = 0;
    private Ugoki ugokiAcition;

    public Transform target;
    // Start is called before the first frame update
    void Start()
    {
        ugokiAcition = new Ugoki();
        ugokiAcition.Enable();
    }

    // Update is called once per frame
    void Update()
    {
        // D キーで右へローテーション
        if (Input.GetKeyDown(KeyCode.D) || ugokiAcition.UI.MoveLeft.triggered)
        {
            sentcIndex++;
            if (sentcIndex >= positions.Length)
                sentcIndex = 0; // インデックスをループさせる

            UpdatePosition();
        }

        // A キーで左へローテーション
        if (Input.GetKeyDown(KeyCode.A) || ugokiAcition.UI.MoveRight.triggered)
        {
            sentcIndex--;
            if (sentcIndex < 0)
                sentcIndex = positions.Length - 1; // インデックスをループさせる

            UpdatePosition();
        }
    }
    void UpdatePosition()
    {
        // ターゲットの位置を更新
        target.position = positions[sentcIndex];
    }
}
