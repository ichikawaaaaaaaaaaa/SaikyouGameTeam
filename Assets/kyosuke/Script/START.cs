using UnityEngine;
using UnityEngine.SceneManagement;

public class NewMonoBehaviourScript : MonoBehaviour
{
    private void OnMouseDown()
    {
        SceneManager.LoadScene("Game Scene");
    }
}
