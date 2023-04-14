using System;
using UnityEngine;

namespace Ejercicio1
{
    public class Movimiento : MonoBehaviour
    {
        [SerializeField]
        private float speed = 5;
        
        [NonSerialized]
        public Vector3 direccion;

        void FixedUpdate()
        {
            transform.position += direccion * speed * Time.deltaTime;
        }
    }
}
