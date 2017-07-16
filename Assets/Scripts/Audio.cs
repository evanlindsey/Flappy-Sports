using UnityEngine;

public class Audio : MonoBehaviour
{
    private static Audio instance = null;

    private AudioSource click, ding, impact, kick, whistle;
    public AudioSource Click { get { return click; } }
    public AudioSource Ding { get { return ding; } }
    public AudioSource Impact { get { return impact; } }
    public AudioSource Kick { get { return kick; } }
    public AudioSource Whistle { get { return whistle; } }


    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        else
            instance = this;

        DontDestroyOnLoad(gameObject);

        var audioSources = GetComponents<AudioSource>();
        click = audioSources[0];
        ding = audioSources[1];
        impact = audioSources[2];
        kick = audioSources[3];
        whistle = audioSources[4];
    }
}
