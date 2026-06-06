using UnityEngine;
using System.Collections.Generic;

public class SkillSystem : MonoBehaviour
{
    public static SkillSystem instance;

    [SerializeField]
    private List<SkillData> learnedSkills =
        new List<SkillData>();

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;

        DontDestroyOnLoad(gameObject);
    }

    public bool HasSkill(
        SkillData skill)
    {
        return learnedSkills
            .Contains(skill);
    }

    public bool CanLearnSkill(
        SkillData skill)
    {
        Debug.Log(
        "CHECK " +
        skill.skillName);
        //if (skill == null)
        //return false;

        if (HasSkill(skill))
        {
            Debug.Log("already");
            return false;
        }

        if (GetSkillPoint()< skill.cost)
        {
            Debug.Log("SP•s‘«");
            return false;
        }

        foreach (var req in skill.requiredSkills)
        {
            Debug.Log(
                req.skillName +
                ":" +
                HasSkill(req));

            if (!HasSkill(req))
                return false;
        }

        //if (skill.requiredSkills
        //    != null)
        //{
        //    foreach (
        //        var req
        //        in skill.requiredSkills)
        //    {
        //        if (!HasSkill(req))
        //            return false;
        //    }
        //}

        return true;
    }

    public void LearnSkill(
        SkillData skill)
    {
        if (!CanLearnSkill(skill))
            return;

        learnedSkills.Add(skill);

        ScoreManager.instance
            .AddSkillPoint(
            -skill.cost);
    }

    public int GetSkillPoint()
    {
        if (ScoreManager.instance
            == null)
            return 0;

        return ScoreManager.instance
            .GetTotalSkillPoint();
    }

    public List<SkillData>
        GetLearnedSkills()
    {
        return learnedSkills;
    }
}