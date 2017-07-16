using UnityEngine;

public class PlayerControl : MonoBehaviour
{
    public float climbSpeed, rotateSpeed, size;

    private AudioSource kick;
    private Rigidbody2D rigidBody;

    private bool stop, start;
    private int sensorCount;
    public bool Stop { get { return stop; } set { stop = value; } }
    public bool Start { get { return start; } set { start = value; } }
    public int SensorCount { get { return sensorCount; } set { sensorCount = value; } }


    void Awake()
    {
        kick = GameObject.Find("Audio").GetComponent<Audio>().Kick;
        rigidBody = GetComponent<Rigidbody2D>();
    }

    void Update()
    {
        if (start)
        {
            Time.timeScale = 1;

            if (Input.GetMouseButtonDown(0))
            {
                if (!stop)
                    ClimbUp();
            }
        }
        else
            Time.timeScale = 0;
    }

    void FixedUpdate()
    {
        if (transform.eulerAngles.z > 1)
            transform.Rotate(0, 0, -2);

        Vector3 theScale = transform.localScale;
        theScale.x = size;
        theScale.y = size;
        transform.localScale = theScale;
    }

    void ClimbUp()
    {
        kick.Play();
        rigidBody.AddForce(new Vector2(0f, climbSpeed));
        transform.Rotate(0, 0, rotateSpeed);
    }
}
