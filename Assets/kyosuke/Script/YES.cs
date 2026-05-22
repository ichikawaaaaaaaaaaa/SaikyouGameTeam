using UnityEngine;
using UnityEngine.SceneManagement;

public class YES : MonoBehaviour
{
    private void OnMouseDown()
    {
        SceneManager.LoadScene("Game Scene");
    }
}