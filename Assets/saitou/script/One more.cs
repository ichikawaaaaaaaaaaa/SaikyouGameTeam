using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Onemore : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip clickSE;
    Vector3 originalScale;
    void Start()
    {
        originalScale = transform.localScale;
    }
    public void OnMouseDown()
    {
        StartCoroutine(ChangeScene());
    }

    IEnumerator ChangeScene()
    {
        transform.localScale = originalScale * 0.9f;
        audioSource.PlayOneShot(clickSE);
        yield return new WaitForSeconds(0.1f);

        transform.localScale = originalScale;

        WaveManager.wave = 0;
        yield return new WaitForSeconds(0.3f);

        SceneManager.LoadScene("WeaponScene");
    }
}