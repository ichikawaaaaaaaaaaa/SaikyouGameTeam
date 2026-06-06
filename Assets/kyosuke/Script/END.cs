using UnityEngine;
using System.Collections;

public class END : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip clickSE;

    public void OnClickEndButton()
    {
        StartCoroutine(PlaySEAndQuit());
    }

    private IEnumerator PlaySEAndQuit()
    {
        audioSource.PlayOneShot(clickSE);

        yield return new WaitForSeconds(1.0f);

#if UNITY_EDITOR
        UnityEditor.EditorApplication.isPlaying = false;
#else
        Application.Quit();
#endif
    }
}
