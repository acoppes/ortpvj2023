using System;
using UnityEngine;

namespace Ejercicios
{
    public class Movimiento : MonoBehaviour
    {
        public Rigidbody2D body;
        
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

        private void OnDisable()
        {
            walking = false;
            body.velocity = Vector2.zero;
        }

        private void FixedUpdate()
        {
            var direction = desiredDirection.normalized;
            
            velocity = direction * speed;
            velocity.y *= perspectiva;

            walking = velocity.SqrMagnitude() > Mathf.Epsilon;

            body.velocity = velocity;
        }
    }
}