using TMPro;
using UnityEngine;
using System.Collections;

public class SpawnManager : MonoBehaviour
{
    [Header("Wave‚²‚Æ‚ÌPrefab")]
    public GameObject[] wavePrefabs;

    public float spawnChance = 0.3f;
    public float timeBetweenWaves = 10f;

    public TextMeshProUGUI waveText;
    public TextMeshProUGUI timerText;

    // ’Ç‰Á
    public ScoreManager scoreManager;

    private Spawner[] spawners;
    private int wave = 0;

    void Start()
    {
        spawners = GetComponentsInChildren<Spawner>();
        StartCoroutine(WaveLoop());
    }

    void ClearEnemies()
    {
        GameObject[] enemies = GameObject.FindGameObjectsWithTag("Grass");

        int removed = 0;

        foreach (var enemy in enemies)
        {
            Destroy(enemy);
            removed++;
        }

       
    }

    IEnumerator WaveLoop()
    {
        while (true)
        {
            wave++;
            UpdateWaveUI();

            ClearEnemies();

            RunWave();

            float timer = timeBetweenWaves;

            while (timer > 0)
            {
                timer -= Time.deltaTime;
                UpdateTimerUI(timer);
                yield return null;
            }
        }
    }

    void RunWave()
    {
        GameObject currentPrefab = GetPrefabForWave();

        if (currentPrefab == null)
        {
            Debug.LogError("Prefab‚ªÝ’è‚³‚ê‚Ä‚¢‚Ü‚¹‚ñI");
            return;
        }

        foreach (var spawner in spawners)
        {
            spawner.TrySpawn(spawnChance, currentPrefab);
        }
    }

    GameObject GetPrefabForWave()
    {
        if (wavePrefabs.Length == 0)
            return null;

        int index = wave - 1;

        if (index >= wavePrefabs.Length)
            index = wavePrefabs.Length - 1;

        return wavePrefabs[index];
    }

    void UpdateWaveUI()
    {
        waveText.text = "Wave: " + wave;
    }

    void UpdateTimerUI(float time)
    {
        timerText.text = "Next: " + Mathf.Ceil(time) + "s";
    }
}