using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ReproductorSonidos : MonoBehaviour
{
    public AudioSource source;

    public AudioClip clip1;

    public GameObject explosionPrefab;

    // Update is called once per frame
    void Update()
    {
        if (Input.GetKeyUp(KeyCode.Alpha1))
        {
            source.Play();
            }    
        
        if (Input.GetKeyUp(KeyCode.Alpha2))
        {
            source.PlayOneShot(clip1);
        }    
        
        if (Input.GetKeyUp(KeyCode.Alpha3))
        {
            var explosion = GameObject.Instantiate(explosionPrefab);
            explosion.SetActive(true);
        }   
    }
}
