using UnityEngine;

public class WeaponButton : MonoBehaviour
{
    public GameObject weaponSelectUI;
    public GameObject confirmWindow;
    public GameObject lockWindow;

    public bool unlocked;

    public void OnMouseDown()
    {
        weaponSelectUI.SetActive(false);

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