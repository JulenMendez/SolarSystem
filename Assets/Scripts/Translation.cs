using UnityEngine;

public class Translation : MonoBehaviour
{
    public Vector3[] ellipsePoints = new Vector3[0];
    private int _ellipseSegments = 50;
    private float _xScale = 149f;
    private float _zScale = 150f;

    int counter = 0;

    private void Awake()
    {
        CalculateEllipse();
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.GetComponent<MeshRenderer>().material.color = Color.blue;
        for(int i = 0; i < _ellipseSegments; i++)
        {
            Debug.Log(ellipsePoints[i]);
        }

    }

    // Update is called once per frame
    void Update()
    {
        this.transform.position = ellipsePoints[counter];
        counter++;

        if (counter == _ellipseSegments)
        {
            counter = 0;
        }
    }

    private void CalculateEllipse()
    {
        ellipsePoints = new Vector3[_ellipseSegments];

        for (int i = 0; i < _ellipseSegments; i++)
        {
            float _angle = ((float)i / (float)_ellipseSegments) * 360 * Mathf.Deg2Rad;
            float x = Mathf.Cos(_angle) * _xScale;
            float z = Mathf.Sin(_angle) * _zScale;

            ellipsePoints[i] = new Vector3(x, 0f, z);
        }
    }
}
