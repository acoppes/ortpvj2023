using UnityEngine;

namespace Ejercicios
{
    public class Personaje : MonoBehaviour
    {
        public Animator animator;
        public Movimiento movimiento;
        
        private void Update()
        {
            animator.SetBool("walking", movimiento.walking);
            
            if (Mathf.Abs(movimiento.velocity.x) > 0)
            {
                transform.localEulerAngles = new Vector3(0, movimiento.velocity.x < 0 ? 180 : 0, 0);
            }
        }
    }
}
