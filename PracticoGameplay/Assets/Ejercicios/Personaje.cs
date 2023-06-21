using System;
using System.Collections;
using UnityEngine;

namespace Ejercicios
{
    public class Personaje : MonoBehaviour
    {
        public Animator animator;
        public Movimiento movimiento;
        public Health health;
        public Weapon weapon;
        public Ability ability;

        public PowerIcon abilityIcon;
        
        // private void Awake()
        // {
        //     var abilityIconObject = GameObject.Find("PowerIcon_Shield");
        //
        //     if (abilityIconObject != null)
        //     {
        //         abilityIcon = abilityIconObject.GetComponent<PowerIcon>();
        //     }
        // }

        private void Update()
        {
            if (movimiento != null)
            {
                animator.SetBool("walking", movimiento.walking);

                if (Mathf.Abs(movimiento.velocity.x) > 0)
                {
                    transform.localEulerAngles = new Vector3(0, movimiento.velocity.x < 0 ? 180 : 0, 0);
                }
            }

            if (abilityIcon != null)
            {
                abilityIcon.UpdateFromAbility(ability);
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

                var pickupAbility = pickup.GetComponentInChildren<Ability>();
                if (pickupAbility != null)
                {
                    pickupAbility.transform.SetParent(transform, false);
                    pickupAbility.transform.localPosition = new Vector3(0, 0, 0);

                    ability = pickupAbility;
                    
                    ability.OnAbilitySet(this);
                }

                GameObject.Destroy(pickup.gameObject);
            }
        }

        public void Pushback(Vector2 force, float duration)
        {
            StartCoroutine(PusbhackSequence(force, duration));
        }

        private IEnumerator PusbhackSequence(Vector2 force, float duration)
        {
            movimiento.enabled = false;
            
            if (weapon != null)
            {
                weapon.enabled = false;
            }
            
            var body = GetComponent<Rigidbody2D>();
            body.bodyType = RigidbodyType2D.Dynamic;
           //  body.velocity = Vector2.zero;

            body.AddForce(force, ForceMode2D.Impulse);

            yield return new WaitForSeconds(duration);

            body.bodyType = RigidbodyType2D.Kinematic;
            body.velocity = Vector2.zero;
            
            movimiento.enabled = true;
            
            if (weapon != null)
            {
                weapon.enabled = true;
            }
        }
    }
}
