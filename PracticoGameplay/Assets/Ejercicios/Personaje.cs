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
            
            if (movimiento.walking)
            {
                spriteRenderer.flipX = movimiento.velocity.x < 0;
            }
        }
    }
}
