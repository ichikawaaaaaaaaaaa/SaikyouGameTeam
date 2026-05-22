using TMPro;
using UnityEngine;

public class ScoreManager : MonoBehaviour
{
    public static ScoreManager instance;

    public TextMeshProUGUI scoreText;
    public TextMeshProUGUI skillText;

    private int destroyedCount = 0;
    private int skillPoint = 0;

    void Awake()
    {
        instance = this;
    }

    void Start()
    {
        UpdateUI();
    }

    public void AddScore(int amount)
    {
        destroyedCount += amount;
        UpdateUI();
    }

    public void AddSkillPoint(int amount)
    {
        skillPoint += amount;
        UpdateUI();
    }
   

    public int GetSkillPoint()
    {
        return skillPoint;
    }
    void UpdateUI()
    {
        scoreText.text = "GrassCount: " + destroyedCount;
        skillText.text = "SkillPoint: " + skillPoint;
    }
}