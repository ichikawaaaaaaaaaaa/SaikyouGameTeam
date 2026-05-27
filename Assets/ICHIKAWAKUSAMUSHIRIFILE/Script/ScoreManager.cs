using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    private int destroyedCount = 0;
    private int totalSkillPoint = 0;
    private int waveSkillPoint = 0;

    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }

        instance = this;
        DontDestroyOnLoad(gameObject);
    }

    // 草カウント
    public void AddScore(int amount)
    {
        destroyedCount += amount;
    }

    public int GetScore()
    {
        return destroyedCount;
    }

    // スキルポイント追加
    public void AddSkillPoint(int amount)
    {
        totalSkillPoint += amount;
        waveSkillPoint += amount;
    }

    // Wave用
    public int GetWaveSkillPoint()
    {
        return waveSkillPoint;
    }

    public int GetTotalSkillPoint()
    {
        return totalSkillPoint;
    }

    public void ResetWaveSkillPoint()
    {
        waveSkillPoint = 0;
    }
}