using UnityEngine;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager instance;

    [Header("Grid")]
    public int width = 10;
    public int height = 10;

    public float cellSize = 1f;

    [Header("Spawn")]
    public GameObject[] wavePrefabs;

    [Range(0f, 1f)]
    public float spawnChance = 0.3f;

    public Cell[,] grid;

    [Header("Grid Position")]
    public Vector2 gridOffset;

    [Header("Spacing")]
    public float spacingX = 0f;
    public float spacingY = 0f;



    void Awake()
    {
        instance = this;

        CreateGrid();
    }

    void Start()
    {
       
    }

    // グリッド生成
    void CreateGrid()
    {
        grid = new Cell[width, height];

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                grid[x, y] = new Cell();
                grid[x, y].gridPos = new Vector2Int(x, y);
            }
        }
    }

    // waveスポーン
    public void SpawnWave(int wave)
    {
        GameObject prefab = GetPrefabForWave(wave);

        if (prefab == null)
        {
            Debug.LogError("Prefab未設定");
            return;
        }

        ClearGrid();

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                if (Random.value <= spawnChance)
                {
                    SpawnGrass(x, y, prefab);
                }
            }
        }
    }

    // 草スポーン
    public void SpawnGrass(int x, int y, GameObject prefab)
    {
        Vector3 pos = GridToWorld(x, y);

        GameObject obj =
            Instantiate(prefab, pos, Quaternion.identity);

        grid[x, y].currentObject = obj;
    }

    // 収穫
    public void HarvestCell(int x, int y, int damage)
    {
        if (!IsInsideGrid(x, y))
            return;

        Cell cell = grid[x, y];

        if (cell.currentObject == null)
            return;

        Grass grass = cell.currentObject.GetComponent<Grass>();

        if (grass != null)
        {
            grass.TakeDamage(damage);
        }
    }

    //　収穫する範囲
    public void HarvestArea(
      int startX,
      int startY,
      int sizeX,
      int sizeY,
      int damage)
    {
        for (int x = startX; x < startX + sizeX; x++)
        {
            for (int y = startY; y < startY + sizeY; y++)
            {
                HarvestCell(x, y, damage);
            }
        }
    }

    // 全削除
    public void ClearGrid()
    {
        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                if (grid[x, y].currentObject != null)
                {
                    Destroy(grid[x, y].currentObject);
                    grid[x, y].currentObject = null;
                }
            }
        }
    }

    // waveごとのPrefab
    GameObject GetPrefabForWave(int wave)
    {
        if (wavePrefabs.Length == 0)
            return null;

        int index = wave - 1;

        if (index >= wavePrefabs.Length)
        {
            index = wavePrefabs.Length - 1;
        }

        return wavePrefabs[index];
    }

    // 座標変換
    public Vector2Int WorldToGrid(Vector3 worldPos)
    {
        float stepX = cellSize + spacingX;
        float stepY = cellSize + spacingY;

        int x = Mathf.FloorToInt((worldPos.x - gridOffset.x) / stepX);
        int y = Mathf.FloorToInt((worldPos.y - gridOffset.y) / stepY);

        return new Vector2Int(x, y);
    }

    public Vector3 GridToWorld(int x, int y)
    {
        float stepX = cellSize + spacingX;
        float stepY = cellSize + spacingY;

        return new Vector3(
            gridOffset.x + x * stepX + cellSize * 0.5f,
            gridOffset.y + y * stepY + cellSize * 0.5f,
            0
        );
    }

    bool IsInsideGrid(int x, int y)
    {
        return x >= 0 &&
               y >= 0 &&
               x < width &&
               y < height;
    }

    //　草があとどれくらいあるか
    public int GetRemainingObjects()
    {
        int count = 0;

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                if (grid[x, y].currentObject != null)
                    count++;
            }
        }

        return count;
    }
}