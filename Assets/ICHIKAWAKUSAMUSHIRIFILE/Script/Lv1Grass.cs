using UnityEngine;

public class Lv1Grass : MonoBehaviour
{
    public Sprite clickedSprite;
    public float destroyDelay = 0.2f;

    [Header("この草のデータ")]
    public int score = 1;
    public int point = 1;

    private SpriteRenderer sr;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void OnMouseDown()
    {
        Debug.Log("クリックされた！");

        // スコア加算
        if (ScoreManager.instance != null)
        {
            ScoreManager.instance.AddScore(score);
            ScoreManager.instance.AddSkillPoint(point);
        }

        // 画像変更
        if (clickedSprite != null)
        {
            sr.sprite = clickedSprite;
        }

        // 削除
        Destroy(gameObject, destroyDelay);
    }
}