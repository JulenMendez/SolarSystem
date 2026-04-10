using UnityEngine;

public class Translation : MonoBehaviour
{
    
    public int ellipseSegments = 50;
    public float avgSunDistance;
    public float e;
    public float orbitalPeriod;
    
    private Vector3[] _ellipsePoints = new Vector3[0];
    private float _xScale;
    private float _zScale;
    private float _orbitalPeriofSeconds;
    private Vector3 _origin;
    private Vector3 _destiny;

    int counter = 0;

    private void Awake()
    {
        _zScale = avgSunDistance;
        _xScale = avgSunDistance * Mathf.Sqrt(1 - Mathf.Pow(e, 2));

        CalculateEllipse();
        
        _origin = _ellipsePoints[counter];
        _destiny = _ellipsePoints[counter + 1];

        this.transform.position = _origin;
    }


    // Start is called once before the first execution of Update after the MonoBehaviour is created
    void Start()
    {
        this.GetComponent<MeshRenderer>().material.color = Color.blue;

        _orbitalPeriofSeconds = (orbitalPeriod * 365 * 24 * 60 * 60)/1000000;
        

    }

    // Update is called once per frame
    void Update()
    {

        _origin.y = this.transform.position.y;
        _destiny.y = this.transform.position.y;
        move(_origin, _destiny);

        if (this.transform.position == _destiny)
        {
            nextDestiny();
        }


        
    }



    void move(Vector3 origin, Vector3 destiny)
    {
        Vector3 direction = destiny - origin;
        float velocity =  direction.magnitude / (_orbitalPeriofSeconds / ellipseSegments);
        this.transform.position += direction.normalized * velocity * Time.deltaTime;

        Vector3 myDirection = destiny - this.transform.position;
        if (direction.normalized != myDirection.normalized)
        {
            this.transform.position = destiny;
        }
    }



    void nextDestiny()
    {
        _origin = _destiny;
        
        counter++;

        if (counter == ellipseSegments)
        {
            counter = 0;
        }

        _destiny = _ellipsePoints[counter];
    }


    private void CalculateEllipse()
    {
        _ellipsePoints = new Vector3[ellipseSegments];

        for (int i = 0; i < ellipseSegments; i++)
        {
            float _angle = ((float)i / (float)ellipseSegments) * 360 * Mathf.Deg2Rad;
            float x = Mathf.Cos(_angle) * _xScale;
            float z = Mathf.Sin(_angle) * _zScale;

            _ellipsePoints[i] = new Vector3(x, 0f, z);
        }
    }
}
