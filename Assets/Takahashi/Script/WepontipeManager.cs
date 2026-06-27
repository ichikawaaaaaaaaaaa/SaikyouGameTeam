using UnityEngine;

public class Wepontipe : MonoBehaviour
{
    public PlayerStats stats;

    public void Wepon(SkillData skillData)
    {
        switch (skillData.wepontipe)
        {
            case WeponType.Wepon01:
                stats.weponUnlock01 = true;
                break;

            case WeponType.Wepon02:
                stats.weponUnlock02 = true;
                break;

            case WeponType.Wepon03:
                stats.weponUnlock03 = true;
                break;

            case WeponType.Wepon04:
                stats.weponUnlock04 = true;
                break;

            case WeponType.Wepon05:
                stats.weponUnlock05 = true;
                break;

            case WeponType.Wepon06:
                stats.weponUnlock06 = true;
                break;

            case WeponType.Wepon07:
                stats.weponUnlock07 = true;
                break;

            case WeponType.Wepon08:
                stats.weponUnlock08 = true;
                break;

            case WeponType.Wepon09:
                stats.weponUnlock09 = true;
                break;
        }
    }
}