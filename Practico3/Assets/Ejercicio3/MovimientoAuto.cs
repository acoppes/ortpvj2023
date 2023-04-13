using System;
using UnityEngine;

namespace Ejercicio3
{
    public class MovimientoAuto : MonoBehaviour
    {
        [SerializeField]
        private float acceleration = 1;
        
        [SerializeField]
        private float forwardSpeed = 1.0f;

        [SerializeField]
        private float backwardSpeed = 0.25f;

        [SerializeField]
        private float rotateSpeed;

        [NonSerialized]
        public float rotate;
        
        [NonSerialized]
        public float forward;

        [SerializeField] 
        private float angle = 0;

        private Vector3 velocity;

        private void FixedUpdate()
        {
            // var targetSpeed = forward > 0 ? forward * forwardSpeed : forward * backwardSpeed;
            var direction = Quaternion.Euler(0, 0, angle) * Vector3.right;

            if (forward > 0)
            {
                velocity += direction  * acceleration * Time.deltaTime;
                
                // Limitamos la velocidad máxima yendo hacia adelante
                if (velocity.sqrMagnitude > forwardSpeed * forwardSpeed)
                {
                    velocity = velocity.normalized * forwardSpeed;
                }
                
            } else if (forward < 0)
            {
                velocity -= direction * acceleration * Time.deltaTime;
                
                // Limitamos la velocidad máxima retrocediendo
                if (velocity.sqrMagnitude > backwardSpeed * backwardSpeed)
                {
                    velocity = velocity.normalized * backwardSpeed;
                }

                // Invertimos el angulo de rotacion al ir para atras
                rotate *= -1;
            }
            else
            {
                velocity = Vector3.zero;
            }
            
            angle += rotate * rotateSpeed * Time.deltaTime;

            transform.position += velocity * Time.deltaTime;
            transform.localEulerAngles = new Vector3(0, 0, angle);
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.blue;
            var direction = Quaternion.Euler(0, 0, angle) * Vector3.right;
            Gizmos.DrawLine(transform.position, transform.position + direction.normalized * 1.0f);
        }
    }
}