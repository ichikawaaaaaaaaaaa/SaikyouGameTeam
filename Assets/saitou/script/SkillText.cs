using TMPro;
using UnityEngine;

public class SkillText : MonoBehaviour
{
    public TextMeshProUGUI skillText;

    void Start()
    {
        skillText.text =
            ScoreManager.instance.GetTotalSkillPoint().ToString();
    }
}