using UnityEngine;

public class GridSpawner : MonoBehaviour
{
    public GameObject prefab;

    public int width = 12;
    public int height = 6;

    public float cellSize = 1f;

    [Range(0f, 1f)]
    public float spawnChance = 0.3f; // 30%

    void Start()
    {
        SpawnObjects();
    }

    void SpawnObjects()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                // Šm—¦”»’è
                if (Random.value <= spawnChance)
                {
                    Vector2 pos = new Vector2(
                        x * cellSize,
                        y * cellSize
                    );

                    Instantiate(prefab, pos, Quaternion.identity);
                }
            }
        }
    }
}