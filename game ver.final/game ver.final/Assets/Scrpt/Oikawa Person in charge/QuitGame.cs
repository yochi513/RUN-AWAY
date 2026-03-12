using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class QuitGame : MonoBehaviour
{
    public AudioSource audioSource; // 効果音用のAudioSource
    public AudioClip buttonSound;   // 効果音のAudioClip
   

    public void OnButtonClick()
    {
        Debug.Log("3");
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
        Quit();
    }

    // ゲームを終了するメソッド
    public void Quit()
    {
        // Unityエディタの場合、再生モードを終了
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        // ビルドされたゲームを終了
        Application.Quit();
#endif
    }
}
