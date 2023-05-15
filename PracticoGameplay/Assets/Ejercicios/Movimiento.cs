using System;
using UnityEngine;

namespace Ejercicios
{
    public class Movimiento : MonoBehaviour
    {
        public float speed;

        public float perspectiva = 0.5f;
        
        [NonSerialized]
        public Vector2 desiredDirection;

        private void FixedUpdate()
        {
            var direction = desiredDirection.normalized;
            var velocity = direction * speed * Time.deltaTime;
            velocity.y *= perspectiva;
            transform.position += (Vector3) velocity;
        }
    }
}