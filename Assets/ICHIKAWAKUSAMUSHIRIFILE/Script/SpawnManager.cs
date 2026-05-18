using TMPro;
using UnityEngine;
using System.Collections;

public class SpawnManager : MonoBehaviour
{
    public static SpawnManager instance;

    [Header("Grid")]
    public int width = 12;
    public int height = 6;

    public float cellSize = 1f;

    [Header("Wave")]
    public GameObject[] wavePrefabs;

    [Range(0f, 1f)]
    public float spawnChance = 0.3f;

    public float timeBetweenWaves = 10f;

    [Header("UI")]
    public TextMeshProUGUI waveText;
    public TextMeshProUGUI timerText;

    public Cell[,] grid;

    private int wave = 0;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        CreateGrid();

        StartCoroutine(WaveLoop());
    }


    // Grid生成

    void CreateGrid()
    {
        grid = new Cell[width, height];

        for (int x = 0; x < width; x++)
        {
            for (int y = 0; y < height; y++)
            {
                grid[x, y] = new Cell();

                grid[x, y].gridPos =
                    new Vector2Int(x, y);
            }
        }
    }

    // Waveループ

    IEnumerator WaveLoop()
    {
        while (true)
        {
            wave++;

            UpdateWaveUI();

            ClearGrid();

            SpawnWave();

            float timer = timeBetweenWaves;

            while (timer > 0)
            {
                timer -= Time.deltaTime;

                UpdateTimerUI(timer);

                yield return null;
            }
        }
    }


    // Waveスポーン

    void SpawnWave()
    {
        GameObject prefab = GetPrefabForWave();

        if (prefab == null)
        {
            Debug.LogError("Prefab未設定");
            return;
        }

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

    public void SpawnGrass(
        int x,
        int y,
        GameObject prefab
    )
    {
        Vector3 pos = GridToWorld(x, y);

        GameObject obj =
            Instantiate(prefab, pos, Quaternion.identity);

        grid[x, y].currentObject = obj;
    }


    // マス収穫

    public void HarvestCell(int x, int y)
    {
        Cell cell = grid[x, y];

        if (cell.currentObject == null)
            return;

        Grass grass =
            cell.currentObject.GetComponent<Grass>();

        if (grass != null)
        {
            grass.Harvest();
        }

        cell.currentObject = null;
    }

    // 範囲収穫

    public void HarvestArea(
        int startX,
        int startY,
        int sizeX,
        int sizeY
    )
    {
        for (int x = startX; x < startX + sizeX; x++)
        {
            for (int y = startY; y < startY + sizeY; y++)
            {
                HarvestCell(x, y);
            }
        }
    }

 
    // 全削除
   
    void ClearGrid()
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

    // WaveごとのPrefab
    GameObject GetPrefabForWave()
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
        int x =
            Mathf.FloorToInt(worldPos.x / cellSize);

        int y =
            Mathf.FloorToInt(worldPos.y / cellSize);

        return new Vector2Int(x, y);
    }

    public Vector3 GridToWorld(int x, int y)
    {
        return new Vector3(
    x * cellSize + cellSize * 0.5f,
    y * cellSize + cellSize * 0.5f,
    0
);
    }

    // 範囲内判定
    
    bool IsInsideGrid(int x, int y)
    {
        return x >= 0 &&
               y >= 0 &&
               x < width &&
               y < height;
    }


    // UI

    void UpdateWaveUI()
    {
        if (waveText != null)
        {
            waveText.text = "Wave : " + wave;
        }
    }

    void UpdateTimerUI(float time)
    {
        if (timerText != null)
        {
            timerText.text =
                "Next : " + Mathf.Ceil(time) + "s";
        }
    }
}