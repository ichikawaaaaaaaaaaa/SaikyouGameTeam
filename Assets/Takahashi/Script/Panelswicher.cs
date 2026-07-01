using UnityEngine;

public class PanelSwitcher : MonoBehaviour
{
    public GameObject panelA;
    public GameObject panelB;
    public GameObject panelC;
    public GameObject panelD;
    public GameObject panelE;
    public GameObject panelF;
    public GameObject panelG;
    public GameObject panelH;
    public GameObject panelI;

    void Start()
    {
        ShowPanelA();
    }

    // 全パネルを非表示
    void HideAllPanels()
    {
        panelA.SetActive(false);
        panelB.SetActive(false);
        panelC.SetActive(false);
        panelD.SetActive(false);
        panelE.SetActive(false);
        panelF.SetActive(false);
        panelG.SetActive(false);
        panelH.SetActive(false);
        panelI.SetActive(false);
    }

    public void ShowPanelA()
    {
        HideAllPanels();
        panelA.SetActive(true);
    }

    public void ShowPanelB()
    {
        HideAllPanels();
        panelB.SetActive(true);
    }

    public void ShowPanelC()
    {
        HideAllPanels();
        panelC.SetActive(true);
    }

    public void ShowPanelD()
    {
        HideAllPanels();
        panelD.SetActive(true);
    }

    public void ShowPanelE()
    {
        HideAllPanels();
        panelE.SetActive(true);
    }

    public void ShowPanelF()
    {
        HideAllPanels();
        panelF.SetActive(true);
    }

    public void ShowPanelG()
    {
        HideAllPanels();
        panelG.SetActive(true);
    }

    public void ShowPanelH()
    {
        HideAllPanels();
        panelH.SetActive(true);
    }

    public void ShowPanelI()
    {
        HideAllPanels();
        panelI.SetActive(true);
    }
}