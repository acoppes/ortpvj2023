using UnityEngine;

namespace Ejercicios
{
    public class SpawnerEnemigos : MonoBehaviour
    {
        public Cooldown cooldown;

        public Transform spawnPosition;
        
        public GameObject enemyPrefab;
        
        private void FixedUpdate()
        {
            cooldown.current += Time.deltaTime;

            if (cooldown.current > cooldown.total)
            {
                SpawnNewEnemy();
                cooldown.current = 0;
            }
        }

        private void SpawnNewEnemy()
        {
            var enemyObject = GameObject.Instantiate(enemyPrefab, spawnPosition.position, spawnPosition.rotation);
            var enemigo = enemyObject.GetComponent<ComportamientoManager>();

            var randomPosition = UnityEngine.Random.insideUnitCircle * 4f;
            enemigo.GetComponentInChildren<ComportamientoMoveToTarget>().targetPosition = transform.position + (Vector3) randomPosition;
        }
    }
}
