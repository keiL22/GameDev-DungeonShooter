using UnityEngine;

public class GameAudio : MonoBehaviour
{
    public static GameAudio instance;
    void Awake()
    {
        DontDestroyOnLoad(this);

        if (GameAudio.instance == null)
        {
            instance = this;
        }
        else
        {
            Destroy(gameObject);
        }
    }
}