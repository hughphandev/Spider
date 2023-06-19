using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class FPSDisplay : MonoBehaviour
{
    TextMeshProUGUI text;
    private float pollingTime = 1.0f;
    private float time;
    private int frameCount;

    private void Awake()
    {
        text = GetComponent<TextMeshProUGUI>();
    }

    void Update()
    {
        time += Time.deltaTime;
        ++frameCount;
        if (time > pollingTime)
        {
            int frameRate = Mathf.RoundToInt(frameCount / time);
            text.text = frameRate.ToString();

            time -= pollingTime;
            frameCount = 0;
        }
    }
}
