using UnityEngine;

namespace Ejercicios
{
    public class Health : MonoBehaviour
    {
        public float current;
        public float total;

        public Animator animator;
        
        public GameObject deathFxPrefab;
        
        public void Damage(float damage)
        {
            current -= damage;

            if (current <= 0)
            {
                GameObject.Instantiate(deathFxPrefab, transform.position, transform.rotation);
                
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