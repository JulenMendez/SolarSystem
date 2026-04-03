using UnityEngine;

public class TimeControler : MonoBehaviour
{
    [Range(0,100)] public float newTimeScale;

    // Update is called once per frame
    void Update()
    {
        Time.timeScale = newTimeScale;
    }
}
