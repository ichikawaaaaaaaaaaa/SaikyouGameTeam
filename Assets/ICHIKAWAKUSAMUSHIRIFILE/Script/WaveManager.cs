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

    [Header("Wave State UI")]
    public TextMeshProUGUI waveStateText;
    public float stateShowTime = 1.5f;

    public static int wave = 0;

    void Start()
    {
        StartCoroutine(WaveLoop());
    }

    IEnumerator WaveLoop()
    {
        SpawnManager spawnManager = SpawnManager.instance;

        // Wave開始演出
        yield return StartCoroutine(ShowWaveState("WAVE " + (wave + 1)));
        yield return new WaitForSeconds(0.5f);

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
                timerFillImage.fillAmount = timer / timeBetweenWaves;

            bool allCleared = spawnManager.GetRemainingObjects() <= 0;
            bool timeUp = timer <= 0;

            if (allCleared)
            {
                clearedByKill = true;
                break;
            }

            if (timeUp)
                break;

            yield return null;
        }

        // 結果表示
        if (clearedByKill)
        {
            yield return StartCoroutine(ShowWaveState("CLEAR!"));
            ScoreManager.instance.AddSkillPoint(10);
        }
        else
        {
            yield return StartCoroutine(ShowWaveState("TIME UP"));
        }

        wave++;

        yield return new WaitForSeconds(1f);

        SceneManager.LoadScene("SkillTest");　// 本来はResultシーン
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

    IEnumerator ShowWaveState(string message)
    {
        if (waveStateText != null)
        {
            waveStateText.gameObject.SetActive(true);
            waveStateText.text = message;
        }

        yield return new WaitForSeconds(stateShowTime);

        if (waveStateText != null)
        {
            waveStateText.gameObject.SetActive(false);
        }
    }
}