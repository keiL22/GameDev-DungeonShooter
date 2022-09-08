using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
using UnityEngine.Audio;

public class Settings : MonoBehaviour
{
    public AudioMixer mainMixer;
    public string menu;
    public Toggle fullscreen;
    public Slider volSlider;
    public Dropdown resolutionDrop;

    List<int> widths = new List<int>() { 1920, 1280, 640 };
    List<int> heights = new List<int>() { 1080, 720, 480 };

    void Start()
    {
        fullscreen.isOn = Screen.fullScreen;
        volSlider.value = PlayerPrefs.GetFloat("vol", Mathf.Log10(0f) * 20);

        int index = 0;

        for (int i =0; i < 3; i++)
        {
            if ((widths[i] == Screen.currentResolution.width) && (heights[i] == Screen.currentResolution.height))
            {
                
                index = i;
            }
        }
        
        resolutionDrop.value = index;
        resolutionDrop.RefreshShownValue();
    }

    public void CloseSettings()
    {
        SceneManager.LoadScene(menu);
    }

    public void Fullscreen()
    {
        Screen.fullScreen = fullscreen.isOn;
    }

    public void Resolution(int index)
    {
        int width = widths[index];
        int height = heights[index];
        Screen.SetResolution(width, height, Screen.fullScreen);
    }

    public void Volume(float vol)
    {
        mainMixer.SetFloat("vol", Mathf.Log10(vol) * 20);
        PlayerPrefs.SetFloat("vol", vol);
    }
}
