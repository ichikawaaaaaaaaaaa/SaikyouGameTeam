using UnityEngine;

public class KusamushiriCounter : MonoBehaviour
{
    public static KusamushiriCounter instance;

    private int waveGrassCount = 0;
    private int waveSkillPoint = 0;
    private int totalGrassCount = 0;

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

    // 草取得
    public void AddGrass(int amount)
    {
        waveGrassCount += amount;
        totalGrassCount += amount;
    }

    // スキルポイント
    public void AddSkillPoint(int amount)
    {
        waveSkillPoint += amount;
    }

    // Wave表示用
    public int GetWaveGrassCount()
    {
        return waveGrassCount;
    }

    public int GetWaveSkillPoint()
    {
        return waveSkillPoint;
    }

    public int GetTotalGrassCount()
    {
        return totalGrassCount;
    }

    // Wave終了時リセット
    public void ResetWaveData()
    {
        waveGrassCount = 0;
        waveSkillPoint = 0;
    }
}