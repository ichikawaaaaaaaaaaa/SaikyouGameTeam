using UnityEngine;
using UnityEngine.SceneManagement;

public class YES : MonoBehaviour
{
    public void OnMouseDown()
    {
        SceneManager.LoadScene("Game Scene");
    }
}