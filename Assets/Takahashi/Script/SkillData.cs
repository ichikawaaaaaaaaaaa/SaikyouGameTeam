using UnityEngine;
using System.Collections.Generic;

[System.Serializable]
public class SkillEffect
{
    [Header("収穫")]
    public int addHarvestSizeX;
    public int addHarvestSizeY;

    [Header("戦闘")]
    public float attackPower;

    [Header("ポイント")]
    public int skillPoint;
}

[CreateAssetMenu(fileName = "Skill", menuName = "SkillTree/Skill")]
public class SkillData : ScriptableObject
{
    [Header("識別情報")]
    public string skillId;

    [Header("表示")]
    public string skillName;

    [TextArea(2, 5)]
    public string description;

    public Sprite icon;

    [Header("取得条件")]
    public int cost;
    public List<SkillData> requiredSkills = new();

    [Header("効果")]
    public SkillEffect effect;

    public WeponType wepontipe;
}