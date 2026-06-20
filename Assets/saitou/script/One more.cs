using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class Onemore : MonoBehaviour
{
    public AudioSource audioSource;
    public AudioClip clickSE;

    public void OnMouseDown()
    {
        StartCoroutine(ChangeScene());
    }

    IEnumerator ChangeScene()
    {
        audioSource.PlayOneShot(clickSE);

        yield return new WaitForSeconds(0.3f);

        SceneManager.LoadScene("GameScene");
    }
}