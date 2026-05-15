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

        foreach (var enemy in enemies)
        {
            Destroy(enemy);
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
        // wave”Ô†‚É‘Î‰ž‚µ‚½PrefabŽæ“¾
        GameObject currentPrefab = GetPrefabForWave();

        foreach (var spawner in spawners)
        {
            spawner.TrySpawn(spawnChance, currentPrefab);
        }
    }

    GameObject GetPrefabForWave()
    {
        // ”z—ñ‚ª‹ó‚È‚çnull
        if (wavePrefabs.Length == 0)
            return null;

        // Wave1 ¨ index0
        int index = wave - 1;

        // ”z—ñ”‚ð’´‚¦‚½‚çÅŒã‚ðŽg‚¢‘±‚¯‚é
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