using UnityEngine;
using System.Collections.Generic;

[CreateAssetMenu(menuName = "SkillTree/Skill")]
public class SkillData : ScriptableObject
{
    public string skillName;

    public string description;

    public int cost;

    

    public List<SkillData> requiredSkills;

    public Sprite icon;
}