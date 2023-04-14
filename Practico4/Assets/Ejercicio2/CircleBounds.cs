using UnityEngine;

namespace Ejercicio2
{
    public class CircleBounds : MonoBehaviour
    {
        [SerializeField]
        private float radius;

        public bool InContact(CircleBounds b)
        {
            var r = radius + b.radius;
            
            var distX = transform.position.x - b.transform.position.x;
            var distY = transform.position.y - b.transform.position.y;

            if (Mathf.Abs(distX) > r)
                return false;

            if (Mathf.Abs(distY) > r)
                return false;

            var distanceSqr = (distX * distX) + (distY * distY);
            return distanceSqr < r * r;
        }

        private void OnDrawGizmos()
        {
            Gizmos.color = Color.yellow;
            Gizmos.DrawWireSphere(transform.position, radius);
        }
    }
}
