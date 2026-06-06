using TMPro;
using UnityEngine;

public class WaveUI : MonoBehaviour
{
    [Header("UI")]
    public TextMeshProUGUI grassText;
    public TextMeshProUGUI skillText;

    void Update()
    {
        if (KusamushiriCounter.instance == null)
            return;

        grassText.text =
            "Grass : " + KusamushiriCounter.instance.GetWaveGrassCount();

        skillText.text =
            "Skill : " + KusamushiriCounter.instance.GetWaveSkillPoint();
    }
}