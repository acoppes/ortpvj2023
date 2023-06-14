using System;
using UnityEngine;

namespace Ejercicios
{
    public class Bullet : MonoBehaviour
    {
        public float speed;

        public int minDamage, maxDamage;
        
        public Cooldown timeToLive;
        
        public GameObject hitFxPrefab;

        public float explosionRange;

        public float pushbackForce;
        public float pusbhackDuration;

        private static Collider2D[] colliders = new Collider2D[100];
        
        public void Fire(Vector2 direction)
        {
            var body = GetComponent<Rigidbody2D>();
            body.AddForce(direction * speed, ForceMode2D.Impulse);
        }

        private void FixedUpdate()
        {
            timeToLive.current += Time.deltaTime;

            if (timeToLive.isReady)
            {
                GameObject.Destroy(gameObject);
            }
        }

        private void OnTriggerEnter2D(Collider2D other)
        {
            Debug.Log("TRIGGER");
            
            if (explosionRange <= Mathf.Epsilon)
            {
                var health = other.gameObject.GetComponentInParent<Health>();
                if (health != null)
                {
                    health.Damage(UnityEngine.Random.Range(minDamage, maxDamage));
                }
            }
            else
            {
                
            }
            
            GameObject.Instantiate(hitFxPrefab, transform.position, transform.rotation);
            GameObject.Destroy(gameObject);
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            if (explosionRange <= Mathf.Epsilon)
            {
                var health = other.gameObject.GetComponentInParent<Health>();
                if (health != null)
                {
                    health.Damage(UnityEngine.Random.Range(minDamage, maxDamage));
                }

            }
            else
            {
                var contactFilter = new ContactFilter2D()
                {
                    useTriggers = true
                };
                
                var collidersFound = Physics2D.OverlapBox(transform.position, new Vector2(explosionRange, explosionRange), 0,
                    contactFilter, colliders);

                for (var i = 0; i < collidersFound; i++)
                {
                    var collider = colliders[i];
                    
                    var personaje = collider.GetComponentInParent<Personaje>();
                    
                    if (personaje != null)
                    {
                        if (personaje.health != null)
                        {
                            personaje.health.Damage(UnityEngine.Random.Range(minDamage, maxDamage));
                        }

                        if (Mathf.Abs(pushbackForce) > 0.01f && pusbhackDuration > 0)
                        {
                            var direction = (transform.position - personaje.transform.position).normalized;
                            personaje.Pushback(direction * pushbackForce, pusbhackDuration);
                        }
                    }
                }
                
            }

            GameObject.Instantiate(hitFxPrefab, transform.position, transform.rotation);
            GameObject.Destroy(gameObject);
        }
    }
}