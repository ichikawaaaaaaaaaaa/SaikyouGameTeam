using UnityEngine;

public class Player: MonoBehaviour
{
    [Header("収穫サイズ")]
    public int harvestSizeX = 1;
    public int harvestSizeY = 1;

    [Header("クールタイム")]
    public float cooldown = 1f;

    private float nextHarvestTime = 0f;

    void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            ClickGrid();
        }
    }

    public void ApplySkill(SkillData skill)
    {
        harvestSizeX += skill.addHarvestSizeX;
        harvestSizeY += skill.addHarvestSizeY;
        cooldown -= skill.cooldownReduction;

        if (cooldown < 0.1f)
            cooldown = 0.1f;
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

        Vector3 mouseWorld =
            Camera.main.ScreenToWorldPoint(Input.mousePosition);

        mouseWorld.z = 0;

        Vector2Int gridPos =
            SpawnManager.instance.WorldToGrid(mouseWorld);

        Debug.Log($"クリックGrid: {gridPos}");

        SpawnManager.instance.HarvestArea(
            gridPos.x,
            gridPos.y,
            harvestSizeX,
            harvestSizeY
        );
    }
}