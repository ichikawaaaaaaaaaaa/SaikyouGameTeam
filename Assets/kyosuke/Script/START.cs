using UnityEngine;
using UnityEngine.SceneManagement;

public class NewMonoBehaviourScript : MonoBehaviour
{
    public void OnMouseDown()
    {
        SceneManager.LoadScene("Game Scene");
    }
}
