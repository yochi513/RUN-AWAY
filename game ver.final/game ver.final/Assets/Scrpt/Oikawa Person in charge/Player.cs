using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class Player : MonoBehaviour
{
    private Timer2 timerScript; // タイマースクリプトへの参照

    void Start()
    {
        // タイマースクリプトを取得
        timerScript = FindObjectOfType<Timer2>();
    }

    // 衝突を検出するメソッド
    private void OnTriggerEnter(Collider other)
    {
        // プレイヤーが"StopObject"タグの付いたオブジェクトに触れた場合
        if (other.CompareTag("StopObject"))
        {
            // タイマーを停止
            if (timerScript != null)
            {
                timerScript.StopTimer();
                SceneManager.LoadScene("clear");
            }
      
        }
    }
}