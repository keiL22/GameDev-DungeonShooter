using UnityEngine;

public class MainMenuAudio : MonoBehaviour
{
    public static MainMenuAudio instance;
    void Awake()
    {
        DontDestroyOnLoad(this);
        
        if(MainMenuAudio.instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }

}
