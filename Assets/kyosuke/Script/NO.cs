using UnityEngine;

public class No : MonoBehaviour
{
    public GameObject weaponSelectUI;
    public GameObject confirmWindow;
    public GameObject lockWindow;
    
    public void OnMouseDown()
    {
        confirmWindow.SetActive(false);
        lockWindow.SetActive(false);

        weaponSelectUI.SetActive(true);
    }
}