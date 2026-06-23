using UnityEngine;
using System.Collections;

public class WeaponButton : MonoBehaviour
{
    public GameObject weaponSelectUI;
    public GameObject confirmWindow;
    public GameObject lockWindow;

    public bool unlocked;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip clickSE;

    public void OnMouseDown()
    {
        StartCoroutine(ClickProcess());
    }

    private IEnumerator ClickProcess()
    {
        audioSource.PlayOneShot(clickSE);

        yield return new WaitForSeconds(0.1f);

        //weaponSelectUI.SetActive(false);

        if (unlocked)
        {
            confirmWindow.SetActive(true);
        }
        else
        {
            lockWindow.SetActive(true);
        }
    }
}