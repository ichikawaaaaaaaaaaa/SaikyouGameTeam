using UnityEngine;

public class Playertest : MonoBehaviour
{
    [Header("収穫サイズ")]
    public int harvestSizeX = 1;
    public int harvestSizeY = 1;

    [Header("クールタイム")]
    public float cooldown = 1f;

    private float nextHarvestTime = 0f;

    // SkillSystemを参照（SkillTreeSceneで覚えたスキルも反映）
    private SkillSystem skillSystem;

    void Start()
    {
        // シーン間で保持されるSkillSystemを取得
        skillSystem = FindObjectOfType<SkillSystem>();

        // スキル効果を反映
        UpdateSkillEffect();
    }

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ClickGrid();
        }
    }

    void ClickGrid()
    {
        // クールタイムチェック
        if (Time.time < nextHarvestTime)
        {
            Debug.Log("クールタイム中");
            return;
        }

        nextHarvestTime = Time.time + cooldown;

        Vector3 mouseWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorld.z = 0;

        Vector2Int gridPos = SpawnManager.instance.WorldToGrid(mouseWorld);

        Debug.Log($"クリックGrid: {gridPos}");

        // 収穫処理
        SpawnManager.instance.HarvestArea(
            gridPos.x,
            gridPos.y,
            harvestSizeX,
            harvestSizeY
        );
    }

    /// <summary>
    /// スキル効果をPlayerに反映する
    /// </summary>
    public void UpdateSkillEffect()
    {
        if (skillSystem == null) return;

        // 基本値にリセット
        harvestSizeX = 1;
        harvestSizeY = 1;
        cooldown = 1f;

        // 収穫サイズスキル
        if (skillSystem.IsSkill(SkillType.harvestSize1))
        {
            harvestSizeX += 1;
            harvestSizeY += 1;
        }
        if (skillSystem.IsSkill(SkillType.harvestSize2))
        {
            harvestSizeX += 1;
            harvestSizeY += 1;
        }
        if (skillSystem.IsSkill(SkillType.harvestSize3))
        {
            harvestSizeX += 2;
            harvestSizeY += 2;
        }

        // クールタイム短縮スキル
        if (skillSystem.IsSkill(SkillType.Cooldown1)) cooldown *= 0.9f;
        if (skillSystem.IsSkill(SkillType.Cooldown2)) cooldown *= 0.8f;
        if (skillSystem.IsSkill(SkillType.Cooldown3)) cooldown *= 0.7f;
        if (skillSystem.IsSkill(SkillType.Cooldown4)) cooldown *= 0.6f;
        if (skillSystem.IsSkill(SkillType.Cooldown5)) cooldown *= 0.5f;

        Debug.Log($"スキル反映 → 収穫サイズ: {harvestSizeX}x{harvestSizeY}, クールタイム: {cooldown}");
    }
}