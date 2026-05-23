using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class SkillParam : MonoBehaviour
{
    [SerializeField] private SkillSystem skillSystem;
    [SerializeField] private SkillType type;
    [SerializeField] private int spendPoint;

    [Header("UI")]
    [SerializeField] private TMP_Text text;

    private Button button;

    void Awake()
    {
        button = GetComponent<Button>();

        // SkillSystem未設定対策（シーン跨ぎ対応）
        if (skillSystem == null)
        {
            skillSystem = SkillSystem.instance;
        }
    }

    void Start()
    {
        SetText();
        CheckButtonOnOff();
    }

    public void OnClick()
    {
        if (skillSystem == null)
        {
            skillSystem = SkillSystem.instance;
        }

        if (skillSystem == null)
        {
            Debug.LogError("SkillSystemが存在しません");
            return;
        }

        if (skillSystem.IsSkill(type))
        {
            text.text = "すでに習得済みです";
            return;
        }

        if (!skillSystem.CanLearnSkill(type, spendPoint))
        {
            text.text = "スキル条件またはポイント不足";
            return;
        }

        skillSystem.LearnSkill(type, spendPoint);

        ChangeButtonColor(new Color(0f, 0.6f, 1f, 1f));
        text.text = $"{type} を習得しました";

        if (Playertest.instance != null)
        {
            Playertest.instance.UpdateSkillEffect();
        }

        CheckButtonOnOff();
    }

    public void CheckButtonOnOff()
    {
        if (skillSystem == null) return;

        if (skillSystem.IsSkill(type))
        {
            ChangeButtonColor(new Color(0.3f, 0.3f, 0.3f, 1f));
            button.interactable = false;
            return;
        }

        if (!skillSystem.CanLearnSkill(type, spendPoint))
        {
            ChangeButtonColor(new Color(0.7f, 0.7f, 0.7f, 1f));
            button.interactable = false;
        }
        else
        {
            ChangeButtonColor(Color.white);
            button.interactable = true;
        }
    }

    public void SetText()
    {
        if (text == null) return;

        text.text =
            $"{type}\n消費スキルポイント：{spendPoint}";
    }

    public void ResetText()
    {
        if (text != null)
        {
            text.text = "";
        }
    }

    public void ChangeButtonColor(Color color)
    {
        if (button == null) return;

        Image img = button.GetComponent<Image>();
        if (img != null)
        {
            img.color = color;
        }

        ColorBlock cb = button.colors;
        cb.normalColor = color;
        cb.selectedColor = color;
        cb.pressedColor = color;
        button.colors = cb;
    }
}