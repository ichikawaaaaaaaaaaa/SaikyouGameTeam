using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public GameObject prefab;       // 全Spawnerが出すプレハブ
    [Range(0f, 1f)]
    public float spawnChance = 0.3f; // 出現確率（親が管理）

    private Spawner[] spawners;

    void Start()
    {
        // 子オブジェクトの Spawner を全部取得
        spawners = GetComponentsInChildren<Spawner>();

        // 全Spawnerに確率判定を実行
        foreach (var spawner in spawners)
        {
            spawner.TrySpawn(spawnChance, prefab);
        }
    }
}
