using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelStart : MonoBehaviour
{
    private SpriteRenderer tap;
    private PlayerControl playerCtrl;
    private AudioSource click, whistle;


    void Awake()
    {
        tap = GetComponent<SpriteRenderer>();
        playerCtrl = GameObject.Find("Player").GetComponent<PlayerControl>();
        click = GameObject.Find("Audio").GetComponent<Audio>().Click;
        whistle = GameObject.Find("Audio").GetComponent<Audio>().Whistle;
    }

    void Update()
    {
        if (Input.GetKeyDown(KeyCode.Escape))
        {
            click.Play();
            if (!playerCtrl.Start)
                SceneManager.LoadScene("Selection");
            else
                SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
        }

        if (Input.GetMouseButtonDown(0))
        {
            if (!playerCtrl.Start)
            {
                whistle.Play();
                tap.enabled = false;
                playerCtrl.Start = true;
            }
        }
    }
}
