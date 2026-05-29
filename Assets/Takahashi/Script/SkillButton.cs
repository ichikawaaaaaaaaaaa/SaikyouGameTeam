using UnityEngine;

public class SkillButton : MonoBehaviour
{
    public SkillData skill;

    public void Click()
    {
        SkillSystem.instance.LearnSkill(skill);
    }
}