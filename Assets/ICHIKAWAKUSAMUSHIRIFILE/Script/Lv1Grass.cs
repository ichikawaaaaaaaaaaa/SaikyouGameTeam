using UnityEngine;

public class Lv1Grass : MonoBehaviour
{
    public Sprite clickedSprite;

    public int score = 1;
    public int point = 1;

    private SpriteRenderer sr;

    void Awake()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    // 収穫時
    public void Harvest()
    {
        // スコア加算
        if (ScoreManager.instance != null)
        {
            ScoreManager.instance.AddScore(score);
            ScoreManager.instance.AddSkillPoint(point);
        }

        // 見た目変更
        if (clickedSprite != null)
        {
            sr.sprite = clickedSprite;
        }

        Destroy(gameObject, 0.1f);
    }
}