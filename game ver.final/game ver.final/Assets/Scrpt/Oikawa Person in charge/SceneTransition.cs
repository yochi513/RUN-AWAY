using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class SceneTransition : MonoBehaviour
{
    public Image fadeImage; // フェード用のImage
    public float fadeDuration = 1f; // フェード時間

    private void Start()
    {
        StartCoroutine(FadeIn()); // シーン開始時にフェードイン
    }

    // フェードイン処理
    private IEnumerator FadeIn()
    {
        float timer = 0f;
        Color color = fadeImage.color;
        color.a = 1f;

        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            color.a = Mathf.Lerp(1f, 0f, timer / fadeDuration);
            fadeImage.color = color;
            yield return null;
        }

        color.a = 0f;
        fadeImage.color = color;
        fadeImage.raycastTarget = false; // フェード後にクリックを受け付けるようにする
    }

    // フェードアウト処理
    public IEnumerator FadeOutAndLoadScene(string sceneName)
    {
        float timer = 0f;
        Color color = fadeImage.color;
        color.a = 0f;
        fadeImage.raycastTarget = true; // フェード中はクリックを防止

        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            color.a = Mathf.Lerp(0f, 1f, timer / fadeDuration);
            fadeImage.color = color;
            yield return null;
        }

        color.a = 1f;
        fadeImage.color = color;

        // シーン移動
        SceneManager.LoadScene("SampletestScene");
    }

    // ボタンから呼び出すメソッド
    public void StartSceneTransition(string sceneName)
    {
        StartCoroutine(FadeOutAndLoadScene(sceneName));
    }
}
