using Cinemachine;
using UnityEngine;
using UnityEngine.Serialization;

namespace Ejercicios
{
    public class Health : MonoBehaviour
    {
        public float current;
        public float total;

        public Animator animator;
        
        public GameObject deathFxPrefab;

        public CinemachineImpulseSource deathImpulseSource;

        public CinemachineImpulseSource hitImpulseSource;
        
        public void Damage(float damage)
        {
            current -= damage;

            if (current <= 0)
            {
                if (deathImpulseSource != null)
                {
                    deathImpulseSource.GenerateImpulse();
                }
                
                GameObject.Instantiate(deathFxPrefab, transform.position, transform.rotation);
                
                GameObject.Destroy(gameObject);
                return;
            }

            if (hitImpulseSource != null)
            {
                hitImpulseSource.GenerateImpulse();
            }
            
            if (animator != null)
            {
                animator.SetTrigger("hit");
            }
        }
    }
}