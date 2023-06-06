using System;
using UnityEngine;

namespace Ejercicios
{
    public class Personaje : MonoBehaviour
    {
        public Animator animator;
        public Movimiento movimiento;
        public Health health;
        
        private void Update()
        {
            animator.SetBool("walking", movimiento.walking);
            
            if (Mathf.Abs(movimiento.velocity.x) > 0)
            {
                transform.localEulerAngles = new Vector3(0, movimiento.velocity.x < 0 ? 180 : 0, 0);
            }
        }

        public void OnDamage(float damage)
        {
            if (animator != null)
            {
                animator.SetTrigger("hit");
            }
        }
    }
}
