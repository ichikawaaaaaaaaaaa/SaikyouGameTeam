using UnityEngine;
using UnityEngine.UI;
using System;

public enum SkillType
{
    Sickle,
    Scythe,

    Cooldown1,
    Cooldown2,
    Cooldown3,
    Cooldown4,
    Cooldown5,

    harvestSize1,
    harvestSize2,
    harvestSize3,

    iharvestSize1,
    iharvestSize2,
    iharvestSize3,
    iharvestSize4,

    iCooldown1,
    iCooldown2,
    iCooldown3,
    iCooldown4,
    iCooldown5,

    charvestSize1,
    charvestSize2,
    charvestSize3,

    cCooldown1,
    cCooldown2,
    cCooldown3,
}

public class SkillSystem : MonoBehaviour
{
    public static SkillSystem instance;

    // スキル所持状態
    [SerializeField] private bool[] skills;

    // UI
    public Text skillText;

    void Awake()
    {
        // シングルトン + シーン跨ぎ保持
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);

        // 初期化（1回だけ）
        if (skills == null || skills.Length == 0)
        {
            skills = new bool[Enum.GetValues(typeof(SkillType)).Length];
        }
    }

    void Start()
    {
        UpdateUI();
    }

    // スキル習得
    public void LearnSkill(SkillType type, int cost)
    {
        if (IsSkill(type)) return; // 二重取得防止

        skills[(int)type] = true;

        ScoreManager.instance.AddSkillPoint(-cost);

        UpdateUI();
    }

    // スキル所持確認
    public bool IsSkill(SkillType type)
    {
        return skills[(int)type];
    }

    // スキルポイント
    public int GetSkillPoint()
    {
        return ScoreManager.instance.GetTotalSkillPoint();
    }

    // 習得可能チェック
    public bool CanLearnSkill(SkillType type, int cost = 0)
    {
        if (GetSkillPoint() < cost) return false;

        // 前提チェック（ツリー）
        switch (type)
        {
            case SkillType.Cooldown2:
                return IsSkill(SkillType.Cooldown1);

            case SkillType.harvestSize1:
                return IsSkill(SkillType.Cooldown2);

            case SkillType.harvestSize2:
                return IsSkill(SkillType.harvestSize1);

            case SkillType.Cooldown3:
                return IsSkill(SkillType.harvestSize2);

            case SkillType.Cooldown4:
                return IsSkill(SkillType.Cooldown3);

            case SkillType.Cooldown5:
                return IsSkill(SkillType.Cooldown4);

            case SkillType.harvestSize3:
                return IsSkill(SkillType.Cooldown5);

            case SkillType.Sickle:
                return IsSkill(SkillType.harvestSize2);

            case SkillType.iharvestSize1:
                return IsSkill(SkillType.Sickle);

            case SkillType.iharvestSize2:
                return IsSkill(SkillType.iharvestSize1);

            case SkillType.iharvestSize3:
                return IsSkill(SkillType.iharvestSize2);

            case SkillType.iharvestSize4:
                return IsSkill(SkillType.iCooldown5);

            case SkillType.iCooldown1:
                return IsSkill(SkillType.iharvestSize3);

            case SkillType.iCooldown2:
                return IsSkill(SkillType.iCooldown1);

            case SkillType.iCooldown3:
                return IsSkill(SkillType.iCooldown2);

            case SkillType.iCooldown4:
                return IsSkill(SkillType.iCooldown3);

            case SkillType.iCooldown5:
                return IsSkill(SkillType.iCooldown4);

            case SkillType.Scythe:
                return IsSkill(SkillType.iCooldown2);

            case SkillType.charvestSize1:
                return IsSkill(SkillType.Scythe);

            case SkillType.cCooldown1:
                return IsSkill(SkillType.charvestSize1);

            case SkillType.cCooldown2:
                return IsSkill(SkillType.cCooldown1);

            case SkillType.charvestSize2:
                return IsSkill(SkillType.cCooldown2);

            case SkillType.charvestSize3:
                return IsSkill(SkillType.charvestSize2);

            case SkillType.cCooldown3:
                return IsSkill(SkillType.charvestSize3);

            default:
                return true;
        }
    }

    // UI更新（必要時のみ呼ぶ）
    public void UpdateUI()
    {
        if (skillText != null)
        {
            skillText.text = "スキルポイント：" + GetSkillPoint();
        }
    }
}