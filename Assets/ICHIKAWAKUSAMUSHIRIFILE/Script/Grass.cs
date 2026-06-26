using UnityEngine;

public class Grass : MonoBehaviour
{
    [Header("Reward")]
    public int score = 1;
    public int skillPoint = 1;

    [Header("HP")]
    public int maxHp = 10;   
    private int currentHp;

    public Sprite clickedSprite;

    private SpriteRenderer sr;

    void Awake()
    {
        //sr = GetComponent<SpriteRenderer>();
        currentHp = maxHp;
    }

    // ƒ_ƒ[ƒW‚ğó‚¯‚é
    public void TakeDamage(int damage)
    {
        currentHp -= damage;

        if (currentHp <= 0)
        {
            Harvest();
        }
    }

    // ûŠn
    public void Harvest()
    {
        ScoreManager.instance.AddScore(score);
        ScoreManager.instance.AddSkillPoint(skillPoint);

        KusamushiriCounter.instance.AddGrass(score);
        KusamushiriCounter.instance.AddSkillPoint(skillPoint);

        //if (clickedSprite != null)
        //    sr.sprite = clickedSprite;

        CursorManager.Instance.PlayHitCursor(0.15f);

        Destroy(gameObject, 0.1f);
    }
}