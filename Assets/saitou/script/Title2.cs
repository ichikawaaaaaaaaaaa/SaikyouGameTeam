using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Title2 : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip clickSE;

    Vector3 originalScale;

    void Start()
    {
        originalScale = transform.localScale;
    }

    public void Title2Down()
    {
        StartCoroutine(ChangeScene());
    }

    IEnumerator ChangeScene()
    {
        // âüÇ≥ÇÍÇΩââèo
        transform.localScale = originalScale * 0.9f;

        audioSource.PlayOneShot(clickSE);

        yield return new WaitForSeconds(0.1f);

        // å≥ÇÃëÂÇ´Ç≥Ç…ñﬂÇ∑
        transform.localScale = originalScale;

        yield return new WaitForSeconds(0.2f);

        SceneManager.LoadScene("TitleScene");
    }
}