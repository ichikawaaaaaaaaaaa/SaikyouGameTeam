using UnityEngine;
using System.Collections;
using UnityEngine.UI;

//　スキルのタイプ
public enum SkillType
{
    Cooldown1,
    Cooldown2,
    harvestSize1,
    harvestSize2,
    Cooldown3,
    Cooldown4,
    Cooldown5,
    harvestSize3
};

public class SkillSystem : MonoBehaviour
{
    //　スキルを覚える為のスキルポイント
    [SerializeField] private int skillPoint;
    //　スキルを覚えているかどうかのフラグ
    [SerializeField] private bool[] skills;
    //　スキル毎のパラメータ
    [SerializeField] private SkillParam[] skillParams;
    //　スキルポイントを表示するテキストUI
    public Text skillText;

    void Awake()
    {
        //　スキル数分の配列を確保
        skills = new bool[skillParams.Length];
        SetText();
    }
    //　スキルを覚える
    public void LearnSkill(SkillType type, int point)
    {
        skills[(int)type] = true;
        SetSkillPoint(point);
        SetText();
        //CheckOnOff();
    }
    //　スキルを覚えているかどうかのチェック
    public bool IsSkill(SkillType type)
    {
        return skills[(int)type];
    }
    //　スキルポイントを減らす
    public void SetSkillPoint(int point)
    {
        skillPoint -= point;
    }
    //　スキルポイントを取得
    public int GetSkillPoint()
    {
        return skillPoint;
    }
    //　スキルを覚えられるかチェック
    public bool CanLearnSkill(SkillType type, int spendPoint = 0)
    {
        //　持っているスキルポイントが足りない
        if (skillPoint < spendPoint)
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
        return true;
    }
   
    void SetText()
    {
        skillText.text = "スキルポイント：" + skillPoint;
    }
}