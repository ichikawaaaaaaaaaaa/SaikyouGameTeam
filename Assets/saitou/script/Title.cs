using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Title : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip clickSE;

    public void TitleDown()
    {
        StartCoroutine(ChangeScene());
    }

    IEnumerator ChangeScene()
    {
        audioSource.PlayOneShot(clickSE);

        yield return new WaitForSeconds(0.3f);

        SceneManager.LoadScene("TitleScene");
    }
}

