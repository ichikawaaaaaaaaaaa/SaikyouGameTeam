using UnityEngine;
using System.Collections;
using UnityEngine.UI;

// スキルのタイプ
public enum SkillType
{
    Sickle,
    Scythe,
    Cooldown1,
    Cooldown2,
    harvestSize1,
    harvestSize2,
    Cooldown3,
    Cooldown4,
    Cooldown5,
    harvestSize3,
    iharvestSize1,
    iharvestSize2,
    iharvestSize3,
    iCooldown1,
    iCooldown2,
    iCooldown3,
    iCooldown4,
    iCooldown5,
    iharvestSize4,
    charvestSize1,
    charvestSize2,
    charvestSize3,
    cCooldown1,
    cCooldown2,
    cCooldown3,
};

public class SkillSystem : MonoBehaviour
{
    // スキルを覚えているかどうか
    [SerializeField] private bool[] skills;

    // スキル毎のパラメータ
    [SerializeField] private SkillParam[] skillParams;

    // スキルポイント表示
    public Text skillText;

    void Awake()
    {
        skills = new bool[skillParams.Length];
    }

    void Start()
    {
        SetText();
    }

    // スキルを覚える
    public void LearnSkill(SkillType type, int point)
    {
        skills[(int)type] = true;

        // ScoreManager のスキルポイントを減らす
        ScoreManager.instance.AddSkillPoint(-point);

        SetText();
    }

    // スキル取得済みか
    public bool IsSkill(SkillType type)
    {
        return skills[(int)type];
    }

    // 現在のスキルポイント取得
    public int GetSkillPoint()
    {
        return ScoreManager.instance.GetSkillPoint();
    }

    // 習得可能か
    public bool CanLearnSkill(SkillType type, int spendPoint = 0)
    {
        // スキルポイント不足
        if (GetSkillPoint() < spendPoint)
        {
            return false;
        }

        if (type == SkillType.Cooldown2)
        {
            return skills[(int)SkillType.Cooldown1];
        }
        else if (type == SkillType.harvestSize1)
        {
            return skills[(int)SkillType.Cooldown2];
        }
        else if (type == SkillType.harvestSize2)
        {
            return skills[(int)SkillType.harvestSize1];
        }
        else if (type == SkillType.Cooldown3)
        {
            return skills[(int)SkillType.harvestSize2];
        }
        else if (type == SkillType.Cooldown4)
        {
            return skills[(int)SkillType.Cooldown3];
        }
        else if (type == SkillType.Cooldown5)
        {
            return skills[(int)SkillType.Cooldown4];
        }
        else if (type == SkillType.harvestSize3)
        {
            return skills[(int)SkillType.Cooldown5];
        }

        if (type == SkillType.Sickle)
        {
            return skills[(int)SkillType.harvestSize2];
        }
        else if (type == SkillType.iharvestSize1)
        {
            return skills[(int)SkillType.Sickle];
        }
        else if (type == SkillType.iharvestSize2)
        {
            return skills[(int)SkillType.iharvestSize1];
        }
        else if (type == SkillType.iharvestSize3)
        {
            return skills[(int)SkillType.iharvestSize2];
        }
        else if (type == SkillType.iCooldown1)
        {
            return skills[(int)SkillType.iharvestSize3];
        }
        else if (type == SkillType.iCooldown2)
        {
            return skills[(int)SkillType.iCooldown1];
        }
        else if (type == SkillType.iCooldown3)
        {
            return skills[(int)SkillType.iCooldown2];
        }

        else if (type == SkillType.iCooldown4)
        {
            return skills[(int)SkillType.iCooldown3];
        }
        else if (type == SkillType.iCooldown5)
        {
            return skills[(int)SkillType.iCooldown4];
        }
        else if (type == SkillType.iharvestSize4)
        {
            return skills[(int)SkillType.iCooldown5];
        }

    //    if (type == SkillType.Scythe)
    //    {
    //        return skills[(int)SkillType.iCooldown2];
    //    }
    //    else if (type == SkillType.charvestSize1)
    //    {
    //        return skills[(int)SkillType.Scythe];
    //    }
    //    else if (type == SkillType.cCooldown1)
    //    {
    //        return skills[(int)SkillType.charvestSize1];
    //    }
    //    else if (type == SkillType.cCooldown2)
    //    {
    //        return skills[(int)SkillType.cCooldown1];
    //    }
    //    else if (type == SkillType.charvestSize2)
    //    {
    //        return skills[(int)SkillType.charvestSize2];
    //    }
    //    else if (type == SkillType.charvestSize3)
    //    {
    //        return skills[(int)SkillType.charvestSize2];
    //    }
    //    else if (type == SkillType.cCooldown3)
    //    {
    //        return skills[(int)SkillType.charvestSize3];
    //    }
       return true;
    }

    void SetText()
    {
        skillText.text = "スキルポイント：" + GetSkillPoint();
    }
}