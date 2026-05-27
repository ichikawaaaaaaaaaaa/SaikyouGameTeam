using TMPro;
using UnityEngine;

public class GameUI : MonoBehaviour
{
    public TextMeshProUGUI grassText;
    public TextMeshProUGUI waveSPText;

    void Update()
    {
        grassText.text = "GrassCount" + ScoreManager.instance.GetScore().ToString();
        waveSPText.text = "SkillPoint"+ ScoreManager.instance.GetWaveSkillPoint().ToString();
    }
}