using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;


public class Titridou : MonoBehaviour
{
    public AudioSource audioSource; // 効果音用のAudioSource
    public AudioClip buttonSound;   // 効果音のAudioClip
    public string nextSceneName = "title";    // 移動先のシーン名
    private Ugoki ugokiAcition;
    void Start()
    {
        ugokiAcition = new Ugoki();
        ugokiAcition.Enable();
    }

   public void Update()
    {

        if (ugokiAcition.UI.Click.triggered)
        {
            OnButtonClick();
        }
    }
    public  void OnButtonClick()
        {
        Debug.Log("1");
        // 効果音を再生
        audioSource.PlayOneShot(buttonSound);

            // 効果音の長さ分待機してからシーンを移動
            StartCoroutine(WaitForSoundToEnd());

        }
    

    private IEnumerator WaitForSoundToEnd()
    {
        // 効果音が終了するまで待機
        yield return new WaitForSeconds(buttonSound.length);

        // シーンを移動
        SceneManager.LoadScene(nextSceneName);
    }
   

}
