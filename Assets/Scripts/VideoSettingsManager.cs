using System;
using System.Collections.Generic;
using TMPro;
using UnityEditor;
using UnityEngine;
using UnityEngine.UI;

public class VideoSettingsManager : MonoBehaviour
{
    public TMP_Dropdown resolutionDropdown;
    public Toggle fullscreenToggle;
    public Toggle framesToggle;
    public TMP_Text FramesText;

    float time;
    float updateRate = 1f;
    int frameCount;


    Resolution[] resolutions;
    bool isFullscreen;

    

    void Start()
    {
        //player prefs if want save player data
        //isFullscreen = true;
        resolutions = Screen.resolutions;
        Resolution currentResolution = Screen.currentResolution;

        for (int i = 0; i < resolutions.Length; i++){
            resolutionDropdown.options.Add(new TMP_Dropdown.OptionData(resolutions[i].ToString()));
        }

        resolutionDropdown.value = Array.IndexOf(resolutions,currentResolution);
    }

    void Update()
    {
        time += Time.deltaTime;

        frameCount++;

        if (time >= updateRate)
        {
            int frameRate = Mathf.RoundToInt(frameCount/time);
            FramesText.text = frameRate.ToString() + " FPS";

            time-=updateRate;
            frameCount=0;
        }   
    }

    public void SetResolution() {
        int currentIndex = resolutionDropdown.value;
        Resolution res = resolutions[currentIndex];
        Screen.SetResolution(res.width, res.height, isFullscreen);
    }

    public void ChangeFullScreen()
    {
        isFullscreen = fullscreenToggle.isOn;
        int currentIndex = resolutionDropdown.value;
        Resolution res = resolutions[currentIndex];
        Screen.SetResolution(res.width, res.height, isFullscreen);
    }

}
