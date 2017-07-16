using UnityEngine;

public class KillTrigger : MonoBehaviour
{
    private AudioSource click;
    private SpriteRenderer over;


    void Awake()
    {
        click = GameObject.Find("Audio").GetComponent<Audio>().Click;
        over = GameObject.Find("Over").GetComponent<SpriteRenderer>();

        over.enabled = false;
    }

    void OnTriggerEnter2D(Collider2D col)
    {
        if (col.gameObject.tag == "Player")
        {
            click.Play();
            over.enabled = true;
        }
    }
}
