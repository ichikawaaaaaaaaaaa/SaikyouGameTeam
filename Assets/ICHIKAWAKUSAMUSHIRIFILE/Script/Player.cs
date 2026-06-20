using UnityEngine;

public class Player: MonoBehaviour
{
    [Header("収穫サイズ")]
    public int harvestSizeX = 1;
    public int harvestSizeY = 1;

    [Header("クールタイム")]
    public float cooldown = 1f;

    [Header("攻撃力")]
    public int attackPower = 1;

    private float nextHarvestTime = 0f;


    void Start()
    {
        ApplyLearnedSkills();//取ったスキル
    }
    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ClickGrid();
        }
    }

    public void ApplySkill(SkillData skill)
    {
        harvestSizeX += skill.effect.addHarvestSizeX;
        harvestSizeY += skill.effect.addHarvestSizeY;

        attackPower += Mathf.RoundToInt(skill.effect.attackPower);
    }

    private void ApplyLearnedSkills()
    {
        var skills = SkillSystem.instance.GetLearnedSkills();

        Debug.Log("スキル数: " + skills.Count);

        foreach (var skill in skills)
        {
            Debug.Log("適用: " + skill.skillName);
            ApplySkill(skill);
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

        Vector2Int center =
            SpawnManager.instance.WorldToGrid(mouseWorld);

        Debug.Log($"クリックGrid中心: {center}");

        int halfX = harvestSizeX / 2;
        int halfY = harvestSizeY / 2;

        for (int x = -halfX; x <= halfX; x++)
        {
            for (int y = -halfY; y <= halfY; y++)
            {
                int targetX = center.x + x;
                int targetY = center.y + y;

                SpawnManager.instance.HarvestArea(  targetX, targetY, 1,  1, attackPower);
            }
        }
    }

}