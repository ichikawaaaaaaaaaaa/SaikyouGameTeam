using UnityEngine;

public class SkillTreeManager : MonoBehaviour
{
    [SerializeField] private Player player;

    public void UnlockSkill(SkillData skill)
    {
        player.ApplySkill(skill);

        Debug.Log($"{skill.skillName} K“¾");
    }
}