using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraParallax : MonoBehaviour
{
    public Transform target;

    public float distance = 10;
    

    // Update is called once per frame
    void Update()
    {
        var position = target.transform.position * distance;
        position.z = transform.position.z;
        transform.position = position;
    }
}
