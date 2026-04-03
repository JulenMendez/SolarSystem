using UnityEngine;

public class TimeControler : MonoBehaviour
{
    public float newTimeScale;

    // Update is called once per frame
    void Update()
    {

        if (newTimeScale < 0)
        {
            newTimeScale = 0;
        }

        Time.timeScale = newTimeScale;
    }
}
