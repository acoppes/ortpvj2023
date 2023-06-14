using System;
using BezierSolution;
using UnityEngine;

public class MoveInPathUsingSpeed : MonoBehaviour
{
    public BezierSpline spline;

    public float speed;

    private float p;

    private int positionIndex;
    private Vector3[] positions;

    private void Start()
    {
        // length = spline.GetLengthApproximately(0, 1, 1000);

        var points = spline.pointCache;
        positions = points.positions;
        
        // Debug.Log(length);
    }

    // Update is called once per frame
    void Update()
    {
        var p0 = transform.position;
        var p1 = positions[positionIndex];  

        var v = (p1 - p0);
        
        var direction = v.normalized;

        transform.position += direction * speed * Time.deltaTime;

        if (v.sqrMagnitude < 0.1f)
        {
            positionIndex = (positionIndex + 1) % positions.Length;
        }
    }
}