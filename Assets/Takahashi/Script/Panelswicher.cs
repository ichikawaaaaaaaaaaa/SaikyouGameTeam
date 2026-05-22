using UnityEngine;

public class PanelSwitcher : MonoBehaviour
{
    public GameObject panelA;
    public GameObject panelB;
    public GameObject panelC;

    void Start()
    {
        ShowPanelA();
    }

    public void ShowPanelA()
    {
        panelA.SetActive(true);
        panelB.SetActive(false);
        panelC.SetActive(false);
    }

    public void ShowPanelB()
    {
        panelA.SetActive(false);
        panelB.SetActive(true);
        panelC.SetActive(false);
    }

    public void ShowPanelC()
    {
        panelA.SetActive(false);
        panelB.SetActive(false);
        panelC.SetActive(true);
    }
}