using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[RequireComponent(typeof(LineRenderer))]
public class ellipse : MonoBehaviour
{
    public LineRenderer lr;

    [Range(3,36)]
    public int segments;
    public float xAxis = 5f;
    public float zAxis = 3f;
    void Start()
    {
        lr = this.GetComponent<LineRenderer>();
        CalculateEllipse();
    }
    void CalculateEllipse(){
        Vector3[] points = new Vector3[segments + 1];
        for (int i=0; i<segments; i++){
            float angle = ((float)i/(float)segments) * 360 * Mathf.Deg2Rad;
            float x = Mathf.Sin (angle) * xAxis;
            float z = Mathf.Cos (angle) * zAxis;
            points [i] = new Vector3(x,0f,z);
        }
        lr.positionCount = segments + 1;
        lr.SetPositions(points);
    }
    void OnValidate(){
        CalculateEllipse();
    }
}
