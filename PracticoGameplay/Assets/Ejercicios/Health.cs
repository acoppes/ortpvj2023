using UnityEngine;

namespace Ejercicios
{
    public class Health : MonoBehaviour
    {
        public float current;
        public float total;

        public void Damage(float damage)
        {
            current -= damage;

            if (current <= 0)
            {
                GameObject.Destroy(gameObject);
            }
        }
    }
}