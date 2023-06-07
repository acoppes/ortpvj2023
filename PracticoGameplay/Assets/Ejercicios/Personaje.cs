using System;
using UnityEngine;

namespace Ejercicios
{
    public class Personaje : MonoBehaviour
    {
        public Animator animator;
        public Movimiento movimiento;
        public Health health;
        public Weapon weapon;
        
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

        private void OnTriggerEnter2D(Collider2D other)
        {
            var pickup = other.GetComponentInChildren<Pickup>();

            if (pickup != null)
            {
                var pickupWeapon = pickup.GetComponent<Weapon>();
                if (pickupWeapon != null)
                {
                    weapon.SetWeapon(pickupWeapon);
                }
                
                GameObject.Destroy(pickup.gameObject);
            }
        }
    }
}
