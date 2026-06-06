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

            KusamushiriCounter.instance.ResetWaveData();

            UpdateWaveUI();

            spawnManager.SpawnWave(wave + 1);

            float timer = timeBetweenWaves;

            bool clearedByKill = false;

            while (true)
            {
                timer -= Time.deltaTime;

                UpdateTimerUI(timer);

                if (timerFillImage != null)
                {
                    timerFillImage.fillAmount = timer / timeBetweenWaves;
                }
                bool allCleared =
                    spawnManager.GetRemainingObjects() <= 0;

                bool timeUp = timer <= 0;

                if (allCleared)
                {
                    clearedByKill = true;
                    break;
                }

                if (timeUp)
                {
                    break;
                }

                yield return null;
            }

            // ‚±‚±‚Å”»’è
            if (clearedByKill)
            {
                ScoreManager.instance.AddSkillPoint(10);
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