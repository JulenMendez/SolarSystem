using UnityEngine;

public class TimeControler : MonoBehaviour
{
    [Range(0,100)] public float newTimeScale;

    // Update is called once per frame
    void Update()
    {

        if (newTimeScale < 0)
        {
            newTimeScale = 0;
        }

        if(newTimeScale > 100)
        {
            newTimeScale = 100;
        }

        Time.timeScale = newTimeScale;
    }
}
