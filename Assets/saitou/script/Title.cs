using UnityEngine;
using UnityEngine.SceneManagement;


public class Title : MonoBehaviour
{
    public void TitleDown()
    {
        SceneManager.LoadScene("Title Scene");
    }
}

