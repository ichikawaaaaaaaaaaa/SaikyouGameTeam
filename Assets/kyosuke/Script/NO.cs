using UnityEngine;
using System.Collections;

public class No : MonoBehaviour
{
    public GameObject weaponSelectUI;
    public GameObject confirmWindow;
    public GameObject lockWindow;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip clickSE;

    public void OnMouseDown()
    {
        StartCoroutine(NoProcess());
    }

    private IEnumerator NoProcess()
    {
        audioSource.PlayOneShot(clickSE);

        yield return new WaitForSeconds(0.1f);

        confirmWindow.SetActive(false);
        lockWindow.SetActive(false);

        weaponSelectUI.SetActive(true);
    }
}