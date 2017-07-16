using UnityEngine;
using UnityEngine.SceneManagement;

public class MenuButtons : MonoBehaviour
{
    public GUIStyle fontStyle;

    private string audioText, scoreText, urlRate;
    private AudioSource click;
    private SpriteRenderer winRupe, title;


    void Awake()
    {
        scoreText = "HIGH SCORE: " + PlayerPrefs.GetInt("Score");
        audioText = "SOUND: ON";

        click = GameObject.Find("Audio").GetComponent<Audio>().Click;
        winRupe = GameObject.Find("WinRupe").GetComponent<SpriteRenderer>();
        title = GetComponent<SpriteRenderer>();

        winRupe.enabled = false;
    }

    void OnGUI()
    {
        GUI.color = Color.white;
        fontStyle.fontSize = Screen.width / 16;

        GUI.Box(new Rect((Screen.width / 4), (Screen.height / 100), (Screen.width / 2), (Screen.height / 12)), scoreText, fontStyle);

        if (GUI.Button(new Rect((Screen.width / 6), (Screen.height / 1.95f), (Screen.width / 1.5f), (Screen.height / 5)), ""))
        {
            click.Play();
            SceneManager.LoadScene("Selection");
        }
        GUI.Label(new Rect((Screen.width / 6), (Screen.height / 1.95f), (Screen.width / 1.5f), (Screen.height / 5)), "PLAY", fontStyle);

        if (GUI.Button(new Rect((Screen.width / 6), (Screen.height / 1.405f), (Screen.width / 1.5f), (Screen.height / 5)), ""))
        {
            click.Play();
            if (winRupe.enabled == false)
            {
                winRupe.enabled = true;
                title.enabled = false;
            }
            else
            {
                winRupe.enabled = false;
                title.enabled = true;
            }
        }
        GUI.Label(new Rect((Screen.width / 6), (Screen.height / 1.405f), (Screen.width / 1.5f), (Screen.height / 5)), "ABOUT", fontStyle);

        if (GUI.Button(new Rect((Screen.width / 6), (Screen.height / 1.098f), (Screen.width / 1.5f), (Screen.height / 12)), ""))
        {
            click.Play();
            if (AudioListener.volume == 1f)
            {
                AudioListener.volume = 0f;
                audioText = "SOUND: OFF";
            }
            else
            {
                AudioListener.volume = 1f;
                audioText = "SOUND: ON";
            }
        }
        GUI.Label(new Rect((Screen.width / 6), (Screen.height / 1.098f), (Screen.width / 1.5f), (Screen.height / 12)), audioText, fontStyle);
    }
}
