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
            
            var health = other.gameObject.GetComponentInParent<Health>();
            if (health != null)
            {
                health.Damage(UnityEngine.Random.Range(minDamage, maxDamage));
            }

            GameObject.Destroy(gameObject);
        }

        private void OnCollisionEnter2D(Collision2D other)
        {
            Debug.Log("COLISION");

            GetComponent<Rigidbody2D>().gravityScale = 1;

            var health = other.gameObject.GetComponentInParent<Health>();
            if (health != null)
            {
                health.Damage(UnityEngine.Random.Range(minDamage, maxDamage));
            }

            GameObject.Instantiate(hitFxPrefab, transform.position, transform.rotation);
            
            GameObject.Destroy(gameObject);
        }
    }
}