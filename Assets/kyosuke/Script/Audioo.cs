using UnityEngine;

public class Audioo : MonoBehaviour
{
    public void PlaySE()
    {
        Debug.Log("SEçƒê∂");
        GetComponent<AudioSource>().Play();
    }
}