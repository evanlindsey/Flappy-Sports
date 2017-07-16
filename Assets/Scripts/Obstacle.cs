using UnityEngine;

public class Obstacle : MonoBehaviour
{
    public float moveSpeed;

    private Rigidbody2D rigidBody;
    private PlayerControl playerCtrl;


    void Awake()
    {
        rigidBody = GetComponent<Rigidbody2D>();
        playerCtrl = GameObject.Find("Player").GetComponent<PlayerControl>();
    }

    void FixedUpdate()
    {
        if (!playerCtrl.Stop)
        {
            rigidBody.velocity = new Vector2(transform.localScale.x * moveSpeed, 0);
            rigidBody.angularVelocity = 0f;
        }
        else
        {
            rigidBody.velocity = new Vector2(0, 0);
            rigidBody.angularVelocity = 0f;
        }
    }
}
