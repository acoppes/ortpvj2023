using UnityEngine;

namespace Ejercicios
{
    public class Health : MonoBehaviour
    {
        public float current;
        public float total;

        public Animator animator;
        
        public void Damage(float damage)
        {
            current -= damage;

            if (current <= 0)
            {
                GameObject.Destroy(gameObject);
                return;
            }
            
            if (animator != null)
            {
                animator.SetTrigger("hit");
            }
        }
    }
}