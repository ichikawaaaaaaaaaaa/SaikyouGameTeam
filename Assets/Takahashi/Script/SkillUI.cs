using UnityEngine;
using TMPro;

public class SkillUI :
    MonoBehaviour
{
    [SerializeField]
    private TMP_Text skillPointText;

    void Update()
    {
        if (
            SkillSystem.instance
            == null)
            return;

        skillPointText.text =
            "SP : "
            +
            SkillSystem.instance
            .GetSkillPoint();
    }
}