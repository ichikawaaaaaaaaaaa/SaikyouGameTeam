using TMPro;
using UnityEngine;

public class SkillTreeUI2 : MonoBehaviour
{
    public TextMeshProUGUI totalSPText;

    void Update()
    {
        totalSPText.text = ScoreManager.instance.GetTotalSkillPoint().ToString();
    }
}