using UnityEngine;

public class Lv1Grass : MonoBehaviour
{
    public Sprite clickedSprite;

    public int score = 1;
    public int point = 1;

    private SpriteRenderer sr;

    // 全体クールタイム
    private static float nextClickTime = 0f;
    public float cooldown = 1f;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void OnMouseDown()
    {
        // クールチェック
        if (Time.time < nextClickTime)
        {
            Debug.Log("クール中で押せない");
            return;
        }

        nextClickTime = Time.time + cooldown;

        Debug.Log("クリック成功");

        // スコア
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

        // 削除
        Destroy(gameObject);
    }
}