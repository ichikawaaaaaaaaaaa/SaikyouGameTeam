using UnityEngine;
using System.Collections;

public class WeaponButton : MonoBehaviour
{
    public GameObject weaponSelectUI;
    public GameObject confirmWindow;
    public GameObject lockWindow;

    public bool unlocked01;
    public bool unlocked02;
    public bool unlocked03;
    public bool unlocked04;
    public bool unlocked05;
    public bool unlocked06;
    public bool unlocked07;
    public bool unlocked08;
    public bool unlocked09;

    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip clickSE;

    public PlayerStats playerStats;

    void Update()
    {
        if (playerStats.weponUnlock01)
            unlocked01 = true;
        if (playerStats.weponUnlock02)
            unlocked01 = true;
        if (playerStats.weponUnlock03)
            unlocked01 = true;
        if (playerStats.weponUnlock04)
            unlocked01 = true;
        if (playerStats.weponUnlock05)
            unlocked01 = true;
        if (playerStats.weponUnlock06)
            unlocked01 = true;
        if (playerStats.weponUnlock07)
            unlocked01 = true;
        if (playerStats.weponUnlock08)
            unlocked01 = true;
        if (playerStats.weponUnlock09)
            unlocked01 = true;
    }

    public void OnMouseDown()
    {
        StartCoroutine(ClickProcess());
    }

    private IEnumerator ClickProcess()
    {
        audioSource.PlayOneShot(clickSE);

        yield return new WaitForSeconds(0.1f);

        //weaponSelectUI.SetActive(false);

        if (unlocked01)
        {
            confirmWindow.SetActive(true);
        }
        else
        {
            lockWindow.SetActive(true);
        }
        if (unlocked02)
        {
            confirmWindow.SetActive(true);
        }
        else
        {
            lockWindow.SetActive(true);
        }
        if (unlocked03)
        {
            confirmWindow.SetActive(true);
        }
        else
        {
            lockWindow.SetActive(true);
        }
        if (unlocked04)
        {
            confirmWindow.SetActive(true);
        }
        else
        {
            lockWindow.SetActive(true);
        }
        if (unlocked05)
        {
            confirmWindow.SetActive(true);
        }
        else
        {
            lockWindow.SetActive(true);
        }
        if (unlocked06)
        {
            confirmWindow.SetActive(true);
        }
        else
        {
            lockWindow.SetActive(true);
        }
        if (unlocked07)
        {
            confirmWindow.SetActive(true);
        }
        else
        {
            lockWindow.SetActive(true);
        }
        if (unlocked08)
        {
            confirmWindow.SetActive(true);
        }
        else
        {
            lockWindow.SetActive(true);
        }
        if (unlocked09)
        {
            confirmWindow.SetActive(true);
        }
        else
        {
            lockWindow.SetActive(true);
        }
    }
}