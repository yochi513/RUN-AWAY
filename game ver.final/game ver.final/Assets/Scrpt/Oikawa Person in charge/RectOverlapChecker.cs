using System.Collections;
using UnityEngine;
using UnityEngine.SceneManagement;

public class RectOverlapChecker : MonoBehaviour
{
    public RectTransform rectA; // 判定対象1
    public RectTransform rectB; // 判定対象2
    public RectTransform rectC;
    public RectTransform rectD;
    private Ugoki ugokiAcition;
    public AudioSource audioSource; // 効果音用のAudioSource
    public AudioClip buttonSound;   // 効果音のAudioClip

    private bool triggerLocked = false; // トリガーを一時的に無効化するフラグ
    public float triggerLockDuration = 1f; // トリガー受付を無効にする時間

    private void Start()
    {
        ugokiAcition = new Ugoki();
        ugokiAcition.Enable();
    }

    void Update()
    {
        if (triggerLocked) return; // トリガーがロックされている間は処理をスキップ

        Rect rect1 = GetScreenRect(rectA);
        Rect rect2 = GetScreenRect(rectB);
        Rect rect3 = GetScreenRect(rectC);
        Rect rect4 = GetScreenRect(rectD);

        if (rect1.Overlaps(rect2) && ugokiAcition.UI.Click.triggered)
        {
            HandleTrigger(WaitForSoundToEnd());
        }
        else if (rect1.Overlaps(rect3) && ugokiAcition.UI.Click.triggered)
        {
            HandleTrigger(WaitForSoundToEnd2());
        }
        else if (rect1.Overlaps(rect4) && ugokiAcition.UI.Click.triggered)
        {
            HandleTrigger(WaitForSoundToEnd3());
        }
    }

    private void HandleTrigger(IEnumerator coroutine)
    {
        // トリガーを無効化し、指定のコルーチンを開始
        triggerLocked = true;
        StartCoroutine(coroutine);
        StartCoroutine(UnlockTriggerAfterDelay());
    }

    private IEnumerator UnlockTriggerAfterDelay()
    {
        // 一定時間後にトリガーを再び有効化
        yield return new WaitForSeconds(triggerLockDuration);
        triggerLocked = false;
    }

    private IEnumerator WaitForSoundToEnd()
    {
        audioSource.PlayOneShot(buttonSound);
        yield return new WaitForSeconds(buttonSound.length);
        SceneManager.LoadScene("SampletestScene"); // 再開
    }

    private IEnumerator WaitForSoundToEnd2()
    {
        audioSource.PlayOneShot(buttonSound);
        yield return new WaitForSeconds(buttonSound.length);
        SceneManager.LoadScene("title"); // タイトル
    }

    private IEnumerator WaitForSoundToEnd3()
    {
        audioSource.PlayOneShot(buttonSound);
        yield return new WaitForSeconds(buttonSound.length);
        Quit();
    }

    private Rect GetScreenRect(RectTransform rectTransform)
    {
        Vector3[] corners = new Vector3[4];
        rectTransform.GetWorldCorners(corners);

        Vector2 bottomLeft = RectTransformUtility.WorldToScreenPoint(null, corners[0]);
        Vector2 topRight = RectTransformUtility.WorldToScreenPoint(null, corners[2]);

        return new Rect(
            bottomLeft.x,
            bottomLeft.y,
            topRight.x - bottomLeft.x,
            topRight.y - bottomLeft.y
        );
    }

    public void Quit()
    {
#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
