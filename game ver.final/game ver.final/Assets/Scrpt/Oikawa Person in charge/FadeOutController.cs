using UnityEngine;
using UnityEngine.UI;
using UnityEngine.SceneManagement;
using System.Collections;

public class FadeOutController : MonoBehaviour
{
    public Image fadeImage; // フェード用Image
    public float fadeDuration = 1f; // フェード時間

    // フェードアウトとシーン遷移を開始
    public void StartFadeOut(string sceneName)
    {
        StartCoroutine(FadeOut("SampletestScene"));
       
    }
    public void StartFadeOut1(string sceneName)
    {
        StartCoroutine(FadeOut1("title"));
    }
   



    private IEnumerator FadeOut(string sceneName)
    {
        float timer = 0f;
        Color color = fadeImage.color;
        color.a = 0f;
        fadeImage.raycastTarget = true; // フェード中のクリック無効化

        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            color.a = Mathf.Lerp(0f, 1f, timer / fadeDuration);
            fadeImage.color = color;
            yield return null;
        }

        color.a = 1f;
        fadeImage.color = color;

        // シーン遷移
        SceneManager.LoadScene("SampletestScene");
    }
    private IEnumerator FadeOut1(string sceneName)
    {
        float timer = 0f;
        Color color = fadeImage.color;
        color.a = 0f;
        fadeImage.raycastTarget = true; // フェード中のクリック無効化

        while (timer < fadeDuration)
        {
            timer += Time.deltaTime;
            color.a = Mathf.Lerp(0f, 1f, timer / fadeDuration);
            fadeImage.color = color;
            yield return null;
        }

        color.a = 1f;
        fadeImage.color = color;

        // シーン遷移
        SceneManager.LoadScene("title");
    }
   



}
