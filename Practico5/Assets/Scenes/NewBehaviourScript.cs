using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class NewBehaviourScript : MonoBehaviour
{
    // Start is called before the first frame update
    void Start()
    {
#if UNITY_EDITOR
        Debug.Log("EDITOR!!");
#endif
        
#if UNITY_WEBGL
        Debug.Log("EDITOR!!");
#endif
        
        #if IS_DEMO_VERSION 
            // disable button to enter new stages
        #endif
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
