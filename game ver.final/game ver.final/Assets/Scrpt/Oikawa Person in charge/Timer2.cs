using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class Timer2 : MonoBehaviour
{
    [SerializeField] int timeLimit;
    [SerializeField] Text timerText;
    [SerializeField] Text timerText2;

    [SerializeField] GameObject Timer;
    [SerializeField] GameObject Timers;

    // static 変数で時間を保持
    static float time;
    private bool isTimerRunning = true;
    private int minutes, seconds, HalfTime;
    //public int Branc, Aranc;



    void Start()
    {
 
        Timer.SetActive(true);
        Timers.SetActive(false);
    }


    void Update()
    {
        if (isTimerRunning)
        {
            // フレーム毎の経過時間をtime変数に追加
            time += Time.deltaTime;
            // time変数をint型にし制限時間から引いた数をint型のremaining変数に代入
            int remaining = timeLimit - (int)time;

            minutes = remaining / 60;
            seconds = remaining % 60;

            // timerTextを更新していく

            //こっちは分で表すタイプの方切り替えしたかったらスラッシュ消してね
            //timerText.text= string.Format("{0:00}:{1:00}",minutes,seconds);
            //timerText2.text = string.Format("{0:00}:{1:00}", minutes, seconds);
            timerText.text = $"{remaining.ToString("D4")}";
            timerText2.text = $"{remaining.ToString("D4")}";

            HalfTime = timeLimit / 3;

            if (remaining == HalfTime)
            {
                Timer.SetActive(false);
                Timers.SetActive(true);

            }

            if (remaining == 0)
            {
                isTimerRunning = false;
                SceneManager.LoadScene("GAMEOVERScene");
            }

        }
        if(!isTimerRunning)
        {
            time = 0;
        }
    }


    public void StopTimer()
    {
        isTimerRunning = false; // タイマーを停止
        float elapsedTime = time; // 経過時間を取得
        Debug.Log($"経過時間: {elapsedTime:F3} 秒");

        // 経過時間をPlayerPrefsに保存
        PlayerPrefs.SetFloat("ElapsedTime", elapsedTime);
        PlayerPrefs.Save();
       
    }

    //public void ScoreTimer()
    //{
    //    if (isTimerRunning)
    //    {
    //        // フレーム毎の経過時間をtime変数に追加
    //        time += Time.deltaTime;
    //        // time変数をint型にし制限時間から引いた数をint型のremaining変数に代入
    //        int Ttime = timeLimit - (int)time;

    //        Aranc = Ttime / 2;
    //        Branc = Ttime / 3;
    //    }

    // }

}