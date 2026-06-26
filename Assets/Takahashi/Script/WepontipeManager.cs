using UnityEngine;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public PlayerStats stats;
    public void wepon (SkillData skillData)
    { switch(skillData.wepontipe)
       {
            case Wepontipe.Wepon01:
                stats.weponUnlock01 = true;
                break;
       }
    }
}
