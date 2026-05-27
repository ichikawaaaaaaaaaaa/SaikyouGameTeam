using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

public class WaveManager : MonoBehaviour
{
    [Header("Wave")]
    public float timeBetweenWaves = 10f;

    [Header("UI")]
    public TextMeshProUGUI waveText;
    public TextMeshProUGUI timerText;
    public Image timerFillImage;

    [Header("Scene Change")]
    public bool moveSceneAfterLastWave = true;

    public static int wave = 0;

    void Start()
    {
        StartCoroutine(WaveLoop());
    }

    IEnumerator WaveLoop()
    {
        SpawnManager spawnManager = SpawnManager.instance;

        while (wave < spawnManager.wavePrefabs.Length)
        {
            UpdateWaveUI();

            spawnManager.SpawnWave(wave + 1);

            float timer = timeBetweenWaves;

            while (timer > 0)
            {
                timer -= Time.deltaTime;

                UpdateTimerUI(timer);

                if (timerFillImage != null)
                {
                    timerFillImage.fillAmount =
                        timer / timeBetweenWaves;
                }

                yield return null;
            }
            wave++;

            SceneManager.LoadScene("SkillTest");
        }
    }

    void UpdateWaveUI()
    {
        if (waveText != null)
        {
            waveText.text = "Wave : " + (wave + 1);
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