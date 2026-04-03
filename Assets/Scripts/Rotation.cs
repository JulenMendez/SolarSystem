using UnityEngine;
using UnityEngine.PlayerLoop;

public class Rotation : MonoBehaviour
{

    public Vector3 rotationVector;
    public float velocity;


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        
    }

    // Update is called once per frame
    void FixedUpdate()
    {
        this.transform.rotation *= Quaternion.Euler(rotationVector * velocity * Time.deltaTime);
    }
}