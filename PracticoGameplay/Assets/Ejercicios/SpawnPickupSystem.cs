using UnityEngine;

namespace Ejercicios
{
    public class SpawnPickupSystem : MonoBehaviour
    {
        public GameObject[] pickupsPrefabs;

        public float chance = 1;
        
        private void OnEnable()
        {
            EventosGenerales.onPersonajeDeath += OnPersonajeDeath;
        }
        
        private void OnDisable()
        {
            EventosGenerales.onPersonajeDeath -= OnPersonajeDeath;
        }

        private void OnPersonajeDeath(GameObject personaje, float damage)
        {

            if (UnityEngine.Random.Range(0f, 1f) > chance)
                return;

            var pickupPrefab = pickupsPrefabs[UnityEngine.Random.Range(0, pickupsPrefabs.Length)];
            var pickupInstance = GameObject.Instantiate(pickupPrefab, personaje.transform.position, Quaternion.identity);
        }
    }
}