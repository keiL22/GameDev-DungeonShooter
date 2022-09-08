using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class MainMenu : MonoBehaviour
{
    public AudioMixer mainMixer;
    public string level;
    public string settings;

    // Start is called before the first frame update
    void Start()
    {
        if (PlayerPrefs.GetFloat("vol", 0f) == 0)
        {
            Debug.Log("zero");
            PlayerPrefs.SetFloat("vol", 1);
        }
        else
        {
            mainMixer.SetFloat("vol", Mathf.Log10(PlayerPrefs.GetFloat("vol", 0f)) * 20);
        }
    }

    public void StartGame()
    {
        MainMenuAudio.instance.GetComponent<AudioSource>().Stop();

        SceneManager.LoadScene(level);
    }

    public void QuitGame()
    {
        Application.Quit();
    }

    public void OpenSettings()
    {
        SceneManager.LoadScene(settings);
    }
}
