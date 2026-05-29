using UnityEngine;
using UnityEngine.UI;
using UnityEngine.EventSystems;
// スキルの状態
public enum SkillState
{
    Locked,     // 押せない
    Available,  // 押せる
    Learned     // 習得済み
}

public class SkillParam : MonoBehaviour
{
    [SerializeField]
    private SkillSystem skillSystem;

    [SerializeField]
    private SkillData skill;

    [Header("UI")]
    [SerializeField]
    public Text text;

    [SerializeField]
    private Text descriptionText;

    private Button button;

    void Awake()
    {
        button = GetComponent<Button>();

        if (skillSystem == null)
            skillSystem = SkillSystem.instance;
    }

    void Start()
    {
        SetText();

        CheckButtonOnOff();
    }
    public SkillState GetState()
    {
        if (skillSystem.HasSkill(skill))
            return SkillState.Learned;

        if (skillSystem.CanLearnSkill(skill))
            return SkillState.Available;

        return SkillState.Locked;
    }

    public void Refresh()
    {
        SkillState state = GetState();

        switch (state)
        {
            case SkillState.Locked:

                button.interactable = false;

                ChangeButtonColor(
                    new Color(
                        0.5f,
                        0.5f,
                        0.5f));

                break;

            case SkillState.Available:

                button.interactable = true;

                ChangeButtonColor(
                    Color.white);

                break;

            case SkillState.Learned:

                button.interactable = false;

                ChangeButtonColor(
                    Color.green);

                break;
        }
    }

    public void OnPointerEnter(
    PointerEventData eventData)
    {
        if (descriptionText == null)
            return;

        descriptionText.text =
            skill.description;
    }

    public void OnPointerExit(
        PointerEventData eventData)
    {
        if (descriptionText == null)
            return;

        descriptionText.text = "";
    }

    public void OnClick()
    {
        if (skillSystem == null)
            skillSystem = SkillSystem.instance;

        if (skillSystem == null)
        {
            Debug.LogError("SkillSystemが存在しません");
            return;
        }

        if (!skillSystem.CanLearnSkill(skill))
        {
            text.text =
                "スキル条件またはポイント不足";

            return;
        }

        skillSystem.LearnSkill(skill);

        text.text =
            skill.skillName +
            " を習得しました";

        UpdateAllSkillButtons();
    }
    void UpdateAllSkillButtons()
    {
        SkillParam[] skills =
            FindObjectsOfType<SkillParam>();

        foreach (var s in skills)
        {
            s.Refresh();
        }
    }

    public void CheckButtonOnOff()
    {
        if (skillSystem == null)
            return;

        if (skillSystem.HasSkill(skill))
        {
            ChangeButtonColor(
                new Color(
                    0.3f,
                    0.3f,
                    0.3f,
                    1f));

            button.interactable = false;

            return;
        }

        if (!skillSystem.CanLearnSkill(skill))
        {
            ChangeButtonColor(
                new Color(
                    0.7f,
                    0.7f,
                    0.7f,
                    1f));

            button.interactable = false;
        }
        else
        {
            ChangeButtonColor(
                Color.white);

            button.interactable = true;
        }
    }

    public void SetText()
    {
        if (text == null || skill == null)
            return;

        text.text =
            $"{skill.skillName}\n" +
            $"消費SP:{skill.cost}";
    }

    public void ResetText()
    {
        if (text != null)
            text.text = "";
    }

    public void ChangeButtonColor(
        Color color)
    {
        Image img =
            button.GetComponent<Image>();

        if (img != null)
            img.color = color;

        ColorBlock cb =
            button.colors;

        cb.normalColor = color;
        cb.selectedColor = color;
        cb.pressedColor = color;

        button.colors = cb;
    }
}