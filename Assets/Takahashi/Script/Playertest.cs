using UnityEngine;

public class Playertest : MonoBehaviour
{
    public static Playertest instance;

    [Header("収穫サイズ")]
    public int harvestSizeX = 1;
    public int harvestSizeY = 1;

    [Header("クールタイム")]
    public float cooldown = 1f;

    private float nextHarvestTime = 0f;

    private SkillSystem skillSystem;

    void Awake()
    {
        // シングルトン化
        if (instance != null)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
    }

    void Start()
    {
        skillSystem = SkillSystem.instance;

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

        SpawnManager.instance.HarvestArea(
            gridPos.x,
            gridPos.y,
            harvestSizeX,
            harvestSizeY
        );
    }

    /// <summary>
    /// スキル効果を反映（外部から呼んでOK）
    /// </summary>
    public void UpdateSkillEffect()
    {
        if (skillSystem == null)
        {
            skillSystem = SkillSystem.instance;
        }

        if (skillSystem == null) return;

        // 初期化
        harvestSizeX = 1;
        harvestSizeY = 1;
        cooldown = 1f;

        // 収穫サイズ系
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

        if (skillSystem.IsSkill(SkillType.iharvestSize1))
        {
            harvestSizeX += 1;
            harvestSizeY += 1;
        }
        if (skillSystem.IsSkill(SkillType.iharvestSize2))
        {
            harvestSizeX += 1;
            harvestSizeY += 1;
        }
        if (skillSystem.IsSkill(SkillType.iharvestSize3))
        {
            harvestSizeX += 2;
            harvestSizeY += 2;
        }
        if (skillSystem.IsSkill(SkillType.iharvestSize4))
        {
            harvestSizeX += 2;
            harvestSizeY += 2;
        }

        if (skillSystem.IsSkill(SkillType.charvestSize1))
        {
            harvestSizeX += 1;
            harvestSizeY += 1;
        }
        if (skillSystem.IsSkill(SkillType.charvestSize2))
        {
            harvestSizeX += 1;
            harvestSizeY += 1;
        }
        if (skillSystem.IsSkill(SkillType.charvestSize3))
        {
            harvestSizeX += 2;
            harvestSizeY += 2;
        }

        // クールタイム系
        if (skillSystem.IsSkill(SkillType.Cooldown1)) cooldown *= 0.9f;
        if (skillSystem.IsSkill(SkillType.Cooldown2)) cooldown *= 0.8f;
        if (skillSystem.IsSkill(SkillType.Cooldown3)) cooldown *= 0.7f;
        if (skillSystem.IsSkill(SkillType.Cooldown4)) cooldown *= 0.6f;
        if (skillSystem.IsSkill(SkillType.Cooldown5)) cooldown *= 0.5f;

        if (skillSystem.IsSkill(SkillType.iCooldown1)) cooldown *= 0.9f;
        if (skillSystem.IsSkill(SkillType.iCooldown2)) cooldown *= 0.8f;
        if (skillSystem.IsSkill(SkillType.iCooldown3)) cooldown *= 0.7f;
        if (skillSystem.IsSkill(SkillType.iCooldown4)) cooldown *= 0.6f;
        if (skillSystem.IsSkill(SkillType.iCooldown5)) cooldown *= 0.5f;

        if (skillSystem.IsSkill(SkillType.cCooldown1)) cooldown *= 0.9f;
        if (skillSystem.IsSkill(SkillType.cCooldown2)) cooldown *= 0.8f;
        if (skillSystem.IsSkill(SkillType.cCooldown3)) cooldown *= 0.7f;

        Debug.Log($"スキル反映 → {harvestSizeX}x{harvestSizeY}, CD:{cooldown}");
    }
}