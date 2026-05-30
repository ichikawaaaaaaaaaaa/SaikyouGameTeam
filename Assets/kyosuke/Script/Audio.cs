using UnityEngine;

public class Audio : MonoBehaviour
{
    public void PlaySE()
    {
        Debug.Log("SEÄ¶");
        GetComponent<AudioSource>().Play();
    }
}