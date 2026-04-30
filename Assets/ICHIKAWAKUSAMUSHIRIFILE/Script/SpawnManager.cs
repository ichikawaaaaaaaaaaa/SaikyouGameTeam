using TMPro;
using UnityEngine;
using System.Collections;

public class SpawnManager : MonoBehaviour
{
    public GameObject prefab;
    public float spawnChance = 0.3f; //　スポーン確率
    public float timeBetweenWaves = 10f; //　ウェーブの時間

    public TextMeshProUGUI waveText;
    public TextMeshProUGUI timerText;

    private Spawner[] spawners;
    private int wave = 0;

    void Start()
    {
        spawners = GetComponentsInChildren<Spawner>();
        StartCoroutine(WaveLoop());
    }

    //　前のウェーブの草を消すやつ
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

            ClearEnemies();//　草削除呼

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
        foreach (var spawner in spawners)
        {
            spawner.TrySpawn(spawnChance, prefab);
        }
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