using UnityEngine;

public class Grass : MonoBehaviour
{
    public int score;
    public int skillPoint;

    public Sprite clickedSprite;

    private SpriteRenderer sr;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    public void Harvest()
    {
        ScoreManager.instance.AddScore(score);
        ScoreManager.instance.AddSkillPoint(skillPoint);

        if (clickedSprite != null)
            sr.sprite = clickedSprite;

        Destroy(gameObject, 0.1f);
    }
}