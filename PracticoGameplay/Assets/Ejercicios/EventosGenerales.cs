using UnityEngine;

namespace Ejercicios
{
    public static class EventosGenerales
    {
        public delegate void OnPersonajeDamagedDelegate(GameObject personaje, float damage);
        
        public static event OnPersonajeDamagedDelegate onPersonajeDamaged;
        public static event OnPersonajeDamagedDelegate onPersonajeDeath;

        public static void OnPersonajeDamaged(GameObject personaje, float damage)
        {
            onPersonajeDamaged?.Invoke(personaje, damage);
        }
        
        public static void OnPersonajeDeath(GameObject personaje, float damage)
        {
            onPersonajeDeath?.Invoke(personaje, damage);
        }
    }
}