using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class YES : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip clickSE;

    public void OnMouseDown()
    {
        StartCoroutine(PlaySEAndLoad());
    }

    private IEnumerator PlaySEAndLoad()
    {
        audioSource.PlayOneShot(clickSE);

        yield return new WaitForSeconds(1.0f);

        SceneManager.LoadScene("KUSAMUSHIRI");
    }
}