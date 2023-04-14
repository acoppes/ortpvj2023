using UnityEngine;

namespace Ejercicio1
{
    public class Follower : MonoBehaviour
    {
        [SerializeField]
        private Transform target;
        
        private void Update()
        {
            var position = transform.position;
            position.x = target.transform.position.x;
            position.y = target.transform.position.y;
            transform.position = position;
        }
    }
}