using UnityEngine;

public class TimeControler : MonoBehaviour
{
    [Range(0,100)] public float newTimeScale;

    private bool paused = false;

    // Update is called once per frame
    void Update()
    {
        if (paused)
        {
            Time.timeScale = 0;
        }
        else
        {
            Time.timeScale = newTimeScale;
        }

        if (Input.GetKeyDown(KeyCode.P))
        {
            paused = !paused;
        }
    }
}
