using System.Collections;
using UnityEngine;
using UnityEngine.Audio;

public class Grass : MonoBehaviour
{
    [Header("Reward")]
    public int score = 1;
    public int skillPoint = 1;

    [Header("HP")]
    public int maxHp = 10;
    private int currentHp;

    [Header("Growth Animation")]
    public Sprite[] grassSprites;   // ê¨í∑âÊëú
    public float changeTime = 2f;    // ïœçXä‘äu

    private SpriteRenderer sr;

    [Header("SE")]
    public AudioClip harvestSE;

    private AudioSource audioSource;

    void Awake()
    {
        currentHp = maxHp;

        sr = GetComponent<SpriteRenderer>();
        audioSource = GetComponent<AudioSource>();

        StartCoroutine(GrowGrass());
    }


    IEnumerator GrowGrass()
    {
        for (int i = 0; i < grassSprites.Length; i++)
        {
            sr.sprite = grassSprites[i];

            yield return new WaitForSeconds(changeTime);
        }
    }


    public void TakeDamage(int damage)
    {
        currentHp -= damage;

        if (currentHp <= 0)
        {
            Harvest();
        }
    }


    public void Harvest()
    {
        ScoreManager.instance.AddScore(score);
        ScoreManager.instance.AddSkillPoint(skillPoint);

        KusamushiriCounter.instance.AddGrass(score);
        KusamushiriCounter.instance.AddSkillPoint(skillPoint);

        CursorManager.Instance.PlayHitCursor(0.15f);

        GetComponent<SpriteRenderer>().enabled = false;
        GetComponent<Collider2D>().enabled = false;

        if (harvestSE != null)
        {
            audioSource.PlayOneShot(harvestSE);
            Destroy(gameObject, harvestSE.length);
        }
        else
        {
            Destroy(gameObject);
        }
    }
}