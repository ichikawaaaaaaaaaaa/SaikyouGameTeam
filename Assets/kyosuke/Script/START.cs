using UnityEngine;
using UnityEngine.SceneManagement;
using System.Collections;

public class START : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip buttonSE;

    public void OnClickSTARTButton()
    {
        StartCoroutine(PlaySEAndLoadScene());
    }

    private IEnumerator PlaySEAndLoadScene()
    {
        audioSource.PlayOneShot(buttonSE);

        yield return new WaitForSeconds(1.0f);

        SceneManager.LoadScene("GameScene");
    }
}