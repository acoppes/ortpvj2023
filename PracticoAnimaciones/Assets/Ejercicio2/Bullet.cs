using UnityEngine;

namespace Ejercicio2
{
    public class Bullet : MonoBehaviour
    {
        public float velocidad;

        public Vector3 direccion;

        public Animator animator;

        private float aliveTime;

        public float convertSpeed = 5f;
        
        // Update is called once per frame
        void Update()
        {
            transform.position += (Vector3) direccion * velocidad * Time.deltaTime;
            aliveTime += Time.deltaTime;
            
            animator.SetFloat("Speed", aliveTime * convertSpeed);
        }
    }
}
