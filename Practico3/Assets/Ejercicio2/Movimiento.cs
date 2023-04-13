using System;
using UnityEngine;

namespace Ejercicio2
{
    public class Movimiento : MonoBehaviour
    {
        [SerializeField]
        private float speed = 1.0f;
        
        [NonSerialized]
        public Vector3 direction;

        private void FixedUpdate()
        {
            transform.position += direction * speed * Time.deltaTime;
        } 
    }
}