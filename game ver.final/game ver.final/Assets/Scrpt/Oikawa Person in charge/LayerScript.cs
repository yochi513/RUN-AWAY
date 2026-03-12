using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class LayerScript : MonoBehaviour
{
    //public LayerMask Minimap;
    public int miniMapLayer = 3;


    private void OnTriggerEnter(Collider other)
    {
        // ミニマップに変更する物かどうかを確認する
        if (other.CompareTag("minimap"))
        {
            // オブジェクトのレイヤーを変更
            other.gameObject.layer = miniMapLayer;


        }
    }
}
