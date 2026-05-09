using UnityEngine;
using UnityEngine.SceneManagement;


public class Title : MonoBehaviour
{
    public void OnTileButtonClick()
    {
        SceneManager.LoadScene("Title Scene");
    }
}

