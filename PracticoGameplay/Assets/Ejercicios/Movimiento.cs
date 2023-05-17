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

        [NonSerialized]
        public bool walking;

        [NonSerialized]
        public Vector2 velocity;
        
        public float minDistanceToTarget = 0.1f;

        public float minDistanceToTargetSqr => minDistanceToTarget * minDistanceToTarget;

        private void FixedUpdate()
        {
            var direction = desiredDirection.normalized;
            
            velocity = direction * speed * Time.deltaTime;
            velocity.y *= perspectiva;

            walking = velocity.SqrMagnitude() > Mathf.Epsilon;
            
            if (walking)
            {
                transform.position += (Vector3)velocity;
            }
        }
    }
}