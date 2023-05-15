using UnityEngine;

namespace Ejercicios
{
    public class Personaje : MonoBehaviour
    {
        public Animator animator;

        public SpriteRenderer spriteRenderer;
        public Movimiento movimiento;
        
        private void Update()
        {
            animator.SetBool("walking", movimiento.walking);
            
            if (Mathf.Abs(movimiento.velocity.x) > 0)
            {
                spriteRenderer.flipX = movimiento.velocity.x < 0;
            }
        }
    }
}
