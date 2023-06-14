using System.Collections;
using System.Collections.Generic;
using BezierSolution;
using UnityEngine;

public class MoveInPath : MonoBehaviour
{
    public BezierSpline spline;

    public float speed;

    private float t;

    // Update is called once per frame
    void Update()
    {
        t += Time.deltaTime * speed;
        transform.position = spline.GetPoint(t);
        
        
    }
}