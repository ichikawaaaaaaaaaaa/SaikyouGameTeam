using UnityEngine;
using System.Collections;
using System.Collections.Generic;
using UnityEngine.UI;


public class en : MonoBehaviour
{
    float speed = 10f;
    float i = 0;
    bool Increase = true;
    RectTransform rectTransform;
    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        rectTransform = GetComponent<RectTransform>();
    }

    // Update is called once per frame
    void Update()
    {
        if (Increase)
        {
            i += speed;
        }
        else
        {
            i -= speed;
        }
        if (i >= 1)
        {
            Increase = false;
        }
        if (i <= 0)
        {
            Increase = true;
        }
        rectTransform.localPosition = new Vector3(i, i, 0);
    }
}
