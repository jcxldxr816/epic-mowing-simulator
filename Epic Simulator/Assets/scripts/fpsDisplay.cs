using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class fpsDisplay : MonoBehaviour
{
    [SerializeField] private Text fpsText;
    [SerializeField] private float hudRefreshRate = .5f;

    private float timer;
    private void Start()
    {
        Application.targetFrameRate = 60;
    }

    // Update is called once per frame
    private void Update()
    {
        if (Time.unscaledTime > timer)
        {
            int fps = (int)(1f / Time.unscaledDeltaTime);
            fpsText.text = "FPS: " + fps;
            timer = Time.unscaledTime + hudRefreshRate;
        }
    }
}
