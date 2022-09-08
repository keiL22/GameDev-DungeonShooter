using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class PauseMenu : MonoBehaviour
{
    public AudioMixer mainMixer;
    public string menu;
    public GameObject pauseMenu;

    void Start()
    {
        GameAudio.instance.GetComponent<AudioSource>().Play();
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            if(Time.timeScale== 0)
            {
                Resume();
            }
            else
            {
                Pause();
            }
        }
    }

    public void Resume()
    {
        pauseMenu.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Pause()
    {
        pauseMenu.SetActive(true);
        Time.timeScale = 0f;
    }

    public void MainMenu()
    {
        GameAudio.instance.GetComponent<AudioSource>().Stop();
        MainMenuAudio.instance.GetComponent<AudioSource>().Play();
        SceneManager.LoadScene(menu);
    }
}