using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class setumei : MonoBehaviour
{
    [SerializeField] Text SetumeiText;
    [SerializeField] GameObject Setumei;
    public float countdownTime = 3f;

    // Start is called before the first frame update
    void Start()
    {
        Setumei.SetActive(true);
        // カウントダウンを開始
        StartCoroutine(CountdownCoroutine());
    }

    IEnumerator CountdownCoroutine()
    {
        float timeRemaining = countdownTime;

        while (timeRemaining > 0)
        {
            // 残り時間を整数に変換して表示
            SetumeiText.text = $"{Mathf.CeilToInt(timeRemaining)}秒後に移動します。";

            // 1フレーム待機
            yield return null;

            // 残り時間を減らす
            timeRemaining -= Time.deltaTime;
        }

        // 最後の1秒の更新を反映
        SetumeiText.text = "0秒後に移動します。";
        if(timeRemaining<0)
        {
            Setumei.SetActive(false);
        }
        
  
    }

}
