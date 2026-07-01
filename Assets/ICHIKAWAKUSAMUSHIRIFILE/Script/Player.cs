using System.Collections.Generic;
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

    public Transform highlight;

    private float nextHarvestTime = 0f;

    public GameObject highlightPrefab;

    private List<GameObject> highlights = new List<GameObject>();

    [Header("Highlight Offset")]
    public Vector2 highlightOffset;

    public static bool canHarvest = true;

    void Start()
    {
        canHarvest = true;

        ApplyLearnedSkills();//取ったスキル
    }
    void Update()
    {
        if (!canHarvest)
            return;

        UpdateHighlight();

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

        int startX = center.x - harvestSizeX / 2;
        int startY = center.y - harvestSizeY / 2;

        SpawnManager.instance.HarvestArea(
            startX,
            startY,
            harvestSizeX,
            harvestSizeY,
            attackPower
        );
    }
    // カーソル合わせた時の範囲のやつ
    void UpdateHighlight()
    {
        // 古いハイライトを削除
        foreach (GameObject h in highlights)
        {
            Destroy(h);
        }
        highlights.Clear();

        // マウス位置取得
        Vector3 mouseWorld = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        mouseWorld.z = 0;

        // マス座標に変換
        Vector2Int center = SpawnManager.instance.WorldToGrid(mouseWorld);

        // 左下の開始位置
        int startX = center.x - harvestSizeX / 2;
        int startY = center.y - harvestSizeY / 2;

        // 収穫範囲分ハイライト生成
        for (int x = 0; x < harvestSizeX; x++)
        {
            for (int y = 0; y < harvestSizeY; y++)
            {
                int gx = startX + x;
                int gy = startY + y;

                // 範囲外ならスキップ
                if (gx < 0 || gy < 0 ||
                    gx >= SpawnManager.instance.width ||
                    gy >= SpawnManager.instance.height)
                {
                    continue;
                }

                Vector3 pos = SpawnManager.instance.GridToWorld(gx, gy);

                pos += (Vector3)highlightOffset;

                GameObject obj = Instantiate(highlightPrefab, pos, Quaternion.identity);
                highlights.Add(obj);
            }
        }
    }

}