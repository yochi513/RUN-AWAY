using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class ScareScene : MonoBehaviour
{
    [SerializeField] Text elapsedTimeText; // 経過時間を表示するUIテキスト
    [SerializeField] TextMeshProUGUI ScoreText;
    [SerializeField] GameObject Sranc;
    [SerializeField] GameObject Aranc;
     [SerializeField] GameObject Branc;
    public Image[] digitImages;       // タイム表示用の桁ごとのImage
    public Sprite[] numberSprites;   // 0〜9の画像スプライト


    float TTime;

    void Start()
    {

        Sranc.SetActive(false);
        Aranc.SetActive(false);
        Branc.SetActive(false);

        
        // PlayerPrefsから経過時間を取得
        float elapsedTime = PlayerPrefs.GetFloat("ElapsedTime", 0f);
        // 経過時間をUIに表示
        // elapsedTimeText.text = $"クリアタイム：{elapsedTime:F2} 秒";
        elapsedTimeText.text = $"         S";
        ShowClearTime(elapsedTime);

        TTime = 0;

        //120秒想定

        if (elapsedTime > 80)//3分の2
        {
            TTime = 1;
        }
        else if (elapsedTime > 60)//半分
        {
            TTime = 2;
        }
        else
        {
            TTime = 3;
        }
    }

     void Update()
    {
        switch (TTime)
        {
            case 1:
                ScoreText.text = "B";
                Branc.SetActive(true);
               // ScoreText.color = new Color(225f / 255f, 84f / 255f, 124f / 255f); // 0～1範囲に変換
                break;
            case 2:
                ScoreText.text = " ";
                Aranc.SetActive (true);

              //  ScoreText.color = new Color(109f / 255f, 132f / 255f, 222f / 255f); // 0～1範囲に変換
                break;
            default:
                ScoreText.text = " ";
                Sranc.SetActive (true);

                //ScoreText.color = new Color(225f / 255f, 226f / 255f, 84f / 255f); // 0～1範囲に変換
                break;
        }
    }
    private void ShowClearTime(float elapsedTime)
    {
        // タイムを整数化（小数点以下切り捨て）
        int timeInSeconds = Mathf.FloorToInt(elapsedTime);

        // タイムを文字列化（例: "123"）
        string timeText = timeInSeconds.ToString("000");

        // 各桁の画像を更新
        for (int i = 0; i < digitImages.Length; i++)
        {
            if (i < timeText.Length)
            {
                int digit = int.Parse(timeText[i].ToString());
                digitImages[i].sprite = numberSprites[digit];
            }
        }
    }
}
