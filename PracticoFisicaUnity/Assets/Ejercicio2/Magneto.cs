using UnityEngine;

namespace Ejercicio2
{
    public class Magneto : MonoBehaviour
    {
        public LayerMask magneticosLayerMask;
        public Collider2D detectorCollider;

        private Collider2D[] collidersDetectados = new Collider2D[100];

        public float attractForce = 10;

        // Update is called once per frame
        void Update()
        {
            var contactFilter = new ContactFilter2D()
            {
                layerMask = magneticosLayerMask,
                useTriggers = false,
                useLayerMask = true
            };
            
            var colliderDetectadosCount =
                Physics2D.OverlapCollider(detectorCollider, contactFilter, collidersDetectados);

            var miPosicion = (Vector2) transform.position;
            
            for (int i = 0; i < colliderDetectadosCount; i++)
            {
                var collider = collidersDetectados[i];
                var body = collider.GetComponent<Rigidbody2D>();
                if (body != null)
                {
                    var direction = (miPosicion - body.position).normalized;
                    body.AddForce(direction * attractForce * Time.deltaTime, ForceMode2D.Force);
                }
            }
        }
    }
}
