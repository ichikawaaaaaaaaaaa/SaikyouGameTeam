using UnityEngine;
using UnityEngine.SceneManagement;

public class SkillTreeUI : MonoBehaviour
{
    public void OpenMainScene()
    {
        SceneManager.LoadScene("MainScene");
    }
}