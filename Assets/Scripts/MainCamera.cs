using UnityEngine;

public class MainCamera : MonoBehaviour
{
    private static MainCamera instance = null;

    private Color bgColor;


    void Awake()
    {
        if (instance != null && instance != this)
        {
            Destroy(gameObject);
            return;
        }
        else
            instance = this;

        DontDestroyOnLoad(gameObject);

        bgColor.r = Random.value;
        bgColor.g = Random.value;
        bgColor.b = Random.value;
        bgColor.a = Random.value;

        var camera = GetComponent<Camera>();
        camera.backgroundColor = bgColor;
    }
}
