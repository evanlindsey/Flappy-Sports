using UnityEngine;

public class Spawner : MonoBehaviour
{
    public float spawnRate;
    public GameObject[] obstacles;

    private float nextSpawn, timer;
    private PlayerControl playerCtrl;


    void Awake()
    {
        playerCtrl = GameObject.Find("Player").GetComponent<PlayerControl>();
    }

    void FixedUpdate()
    {
        timer += Time.time;

        if (!playerCtrl.Stop)
        {
            if (Time.time > nextSpawn)
            {
                nextSpawn = Time.time + spawnRate;
                Spawn();
            }
        }
    }

    void Spawn()
    {
        int obstacleIndex = Random.Range(0, obstacles.Length);
        Instantiate(obstacles[obstacleIndex], transform.position, transform.rotation);
    }
}
