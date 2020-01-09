using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BezierCurve : MonoBehaviour
{
    public LineRenderer Line;

    private int NumberOfPoints = 50;
    private Vector3[] points = new Vector3[50];
    // Start is called before the first frame update
    void Start()
    {
        Line.positionCount = NumberOfPoints;
        CreatePoints();
    }

    // Update is called once per frame
    void Update()
    {

    }
    private void CreatePoints()
    {
        for (int i = 0; i <= NumberOfPoints; i++)
        {
             
        }

    }

    public float Lerp(float a, float b, float rpm)
    {
        return a + (b - a) * rpm;
    }
    public float QuadraticCurve(float a, float b, float c, float rpm)
    {
        return Lerp(Lerp(a, b, rpm), Lerp(b, c, rpm), rpm);
    }
    public float CubicCurve(float a, float b, float c, float d, float rpm)
    {
        return Lerp(QuadraticCurve(a, b, c, rpm), QuadraticCurve(b, c, d, rpm), rpm);
    }
}
