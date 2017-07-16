using UnityEngine;

public class PlayerHealth : MonoBehaviour
{
    private AudioSource impact;
    private Rigidbody2D rigidBody;
    private PlayerControl playerCtrl;


    void Awake()
    {
        impact = GameObject.Find("Audio").GetComponent<Audio>().Impact;
        rigidBody = GetComponent<Rigidbody2D>();
        playerCtrl = GetComponent<PlayerControl>();
    }

    void OnCollisionEnter2D(Collision2D col)
    {
        if (col.gameObject.tag == "Obstacle")
        {
            impact.Play();

            Collider2D[] cols = GetComponents<Collider2D>();
            foreach (Collider2D c in cols)
                c.isTrigger = true;

            transform.eulerAngles = new Vector3(0, 0, 0);
            rigidBody.mass = 10f;

            playerCtrl.Stop = true;
        }
    }
}
