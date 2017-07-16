using UnityEngine;
using UnityEngine.SceneManagement;

public class SelectionScreen : MonoBehaviour
{
    public Texture football, basketball, soccer;

    private AudioSource click;


    void Awake()
    {
        click = GameObject.Find("Audio").GetComponent<Audio>().Click;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            click.Play();
            SceneManager.LoadScene("Menu");
        }
    }

    void OnGUI()
    {
        GUI.color = Color.white;

        if (GUI.Button(new Rect((Screen.width / 6), (Screen.height / 15.1f), (Screen.width / 1.5f), (Screen.height / 3.6f)), football))
        {
            click.Play();
            SceneManager.LoadScene("Football");
        }
        GUI.Label(new Rect((Screen.width / 6), (Screen.height / 15.1f), (Screen.width / 1.5f), (Screen.height / 3.6f)), "");

        if (GUI.Button(new Rect((Screen.width / 6), (Screen.height / 2.91f), (Screen.width / 1.5f), (Screen.height / 3.6f)), basketball))
        {
            click.Play();
            SceneManager.LoadScene("Basketball");
        }
        GUI.Label(new Rect((Screen.width / 6), (Screen.height / 2.91f), (Screen.width / 1.5f), (Screen.height / 3.6f)), "");

        if (GUI.Button(new Rect((Screen.width / 6), (Screen.height / 1.61f), (Screen.width / 1.5f), (Screen.height / 3.6f)), soccer))
        {
            click.Play();
            SceneManager.LoadScene("Soccer");
        }
        GUI.Label(new Rect((Screen.width / 6), (Screen.height / 1.61f), (Screen.width / 1.5f), (Screen.height / 3.6f)), "");
    }
}
