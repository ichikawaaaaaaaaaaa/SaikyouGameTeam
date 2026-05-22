using UnityEngine;

public class WeaponButton : MonoBehaviour
{
    public GameObject confirmWindow;
    public GameObject lockWindow;
    public GameObject confirmWindow1;
    public GameObject lockWindow2;


    public bool unlocked;

    private void OnMouseDown()
    {
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
