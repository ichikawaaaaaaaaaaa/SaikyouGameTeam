using TMPro;
using UnityEngine;

public class WaveText : MonoBehaviour
{
    public TextMeshProUGUI waveText;

    void Start()
    {
        waveText.text = WaveManager.wave.ToString();
    }
}