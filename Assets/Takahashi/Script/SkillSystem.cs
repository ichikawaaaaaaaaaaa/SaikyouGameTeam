using UnityEngine;
using UnityEngine.UI;
using System.Collections.Generic;

public class SkillSystem : MonoBehaviour
{
    public static SkillSystem instance;

    [SerializeField]
    private List<SkillData> learnedSkills =
        new List<SkillData>();

    public Text skillText;

    void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;

       // DontDestroyOnLoad(gameObject);
    }

    void Start()
    {
        UpdateUI();
    }

    public bool HasSkill(SkillData skill)
    {
        return learnedSkills.Contains(skill);
    }

    public bool CanLearnSkill(SkillData skill)
    {
        if (HasSkill(skill))
            return false;

        if (GetSkillPoint() < skill.cost)
            return false;

        foreach (var req in skill.requiredSkills)
        {
            if (!HasSkill(req))
                return false;
        }

        return true;
    }

    public void LearnSkill(SkillData skill)
    {
        if (!CanLearnSkill(skill))
            return;

        int currentSP = GetSkillPoint();

        if (currentSP < skill.cost)
            return;

        learnedSkills.Add(skill);

        ScoreManager.instance.AddSkillPoint(
            -skill.cost);

        UpdateUI();
    }

    public int GetSkillPoint()
    {
        return ScoreManager.instance
            .GetTotalSkillPoint();
    }

    public void UpdateUI()
    {
        if (skillText != null)
        {
            skillText.text =
                "スキルポイント：" +
                GetSkillPoint();
        }
    }
}