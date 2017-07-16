using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelEnd : MonoBehaviour
{
    public GUIStyle fontStyle;

    private int lastScore;
    private AudioSource click;
    private SpriteRenderer over;
    private PlayerControl playerCtrl;


    void Awake()
    {
        lastScore = PlayerPrefs.GetInt("Score");

        click = GameObject.Find("Audio").GetComponent<Audio>().Click;
        over = GetComponent<SpriteRenderer>();
        playerCtrl = GameObject.Find("Player").GetComponent<PlayerControl>();

        over.enabled = false;
    }

    void Update()
    {
        if (playerCtrl.SensorCount > lastScore)
            PlayerPrefs.SetInt("Score", playerCtrl.SensorCount);
    }

    void OnGUI()
    {
        GUI.color = Color.white;
        fontStyle.fontSize = Screen.width / 16;

        if (over.enabled == true)
        {
            int score = PlayerPrefs.GetInt("Score");
            if (playerCtrl.SensorCount == score && score > lastScore)
            {
                string highText = "NEW HIGH SCORE:\n" + score;
                GUI.Box(new Rect(0, (Screen.height / 2.9f), Screen.width, (Screen.height / 6)), "");
                GUI.Label(new Rect((Screen.width / 4), (Screen.height / 2.9f), (Screen.width / 2), (Screen.height / 6)), highText, fontStyle);
            }

            if (GUI.Button(new Rect((Screen.width / 6), (Screen.height / 1.95f), (Screen.width / 1.5f), (Screen.height / 5)), ""))
            {
                click.Play();
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
            }
            GUI.Label(new Rect((Screen.width / 6), (Screen.height / 1.95f), (Screen.width / 1.5f), (Screen.height / 5)), "CONTINUE", fontStyle);

            if (GUI.Button(new Rect((Screen.width / 6), (Screen.height / 1.405f), (Screen.width / 1.5f), (Screen.height / 5)), ""))
            {
                click.Play();
                SceneManager.LoadScene("Menu");
            }
            GUI.Label(new Rect((Screen.width / 6), (Screen.height / 1.405f), (Screen.width / 1.5f), (Screen.height / 5)), "MAIN MENU", fontStyle);
        }
        else
        {
            GUI.Box(new Rect((Screen.width / 2.5f), (Screen.height / 2.9f), Screen.width / 5, (Screen.height / 10)), "");
            GUI.Label(new Rect((Screen.width / 2.5f), (Screen.height / 2.9f), (Screen.width / 5), (Screen.height / 10)), playerCtrl.SensorCount.ToString(), fontStyle);
        }
    }
}
