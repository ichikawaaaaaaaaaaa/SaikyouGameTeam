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

    private int wave = 0;

    void Start()
    {
        StartCoroutine(WaveLoop());
    }

    IEnumerator WaveLoop()
    {
        SpawnManager spawnManager = SpawnManager.instance;

        while (wave < spawnManager.wavePrefabs.Length)
        {
            wave++;

            UpdateWaveUI();

            spawnManager.SpawnWave(wave);

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
        }

        if (moveSceneAfterLastWave)
        {
            SceneManager.LoadScene("SkillTest");
        }
    }

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