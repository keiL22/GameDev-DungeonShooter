using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.Audio;

public class DeathMenu : MonoBehaviour
{
    //serialized fields
    [SerializeField] private GameObject Menu;

    //called before the first frame update
    void Start()
    {
        //ensure death menu is disabled on start
        Menu.SetActive(false);
    }

    //menu activation function
    public void Activate()
    {
        //stop game audio
        GameAudio.instance.GetComponent<AudioSource>().Stop();

        //stop time flow
        Time.timeScale = 0;

        //set menu to active
        Menu.SetActive(true);
    }

    //main menu button activation function
    public void MainMenu()
    {
        //change audio sources to main menu audio
        MainMenuAudio.instance.GetComponent<AudioSource>().Play();

        //load main menu scene
        SceneManager.LoadScene("Main Menu");
    }

    //quit game button activation function
    public void QuitGame()
    {
        //quit the application
        Application.Quit();
    }
}
