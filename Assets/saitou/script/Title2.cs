using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Title2 : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip clickSE;

    public void Title2Down()
    {
        StartCoroutine(ChangeScene());
    }

    IEnumerator ChangeScene()
    {
        audioSource.PlayOneShot(clickSE);

        yield return new WaitForSeconds(0.3f);

        SceneManager.LoadScene("Title Scene");
    }
}