using UnityEngine;

public class Sensor : MonoBehaviour
{
    private AudioSource ding;
    private PlayerControl playerCtrl;


    void Awake()
    {
        ding = GameObject.Find("Audio").GetComponent<Audio>().Ding;
        playerCtrl = GameObject.Find("Player").GetComponent<PlayerControl>();
    }

    void OnTriggerExit2D(Collider2D c)
    {
        if (c.gameObject.tag == "Player")
        {
            ding.Play();
            playerCtrl.SensorCount++;
        }
    }
}
