using UnityEngine;

public class Player1 : MonoBehaviour
{
    public Sprite clickedSprite; // クリック後の画像
    public float destroyDelay = 0.2f; // 消えるまでの時間

    private SpriteRenderer sr;

    void Start()
    {
        sr = GetComponent<SpriteRenderer>();
    }

    void OnMouseDown()
    {
        Debug.Log("クリックされた！");

        // 画像を差し替え
        if (clickedSprite != null)
        {
            sr.sprite = clickedSprite;
        }

        // 少し待ってから消す
        Destroy(gameObject, destroyDelay);
    }
}
