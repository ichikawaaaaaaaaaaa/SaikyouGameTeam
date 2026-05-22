using UnityEngine;

public class No : MonoBehaviour
{
    public GameObject WeaponSelectUI;
    public GameObject ConfirmWindow;
    public GameObject LockWindow;

    public void OnMouseDown()
    {
        Debug.Log("aiu");

        ConfirmWindow.SetActive(false);
        LockWindow.SetActive(false);

        WeaponSelectUI.SetActive(true);
    }
}