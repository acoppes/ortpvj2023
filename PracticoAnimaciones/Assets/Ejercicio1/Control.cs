using UnityEngine;

namespace Ejercicio1
{
    public class Control : MonoBehaviour
    {
        public float velocidad;

        // Update is called once per frame
        void Update()
        {
            var horizontal = Input.GetAxis("Horizontal");
            var direccion = new Vector2(horizontal, 0);

            transform.position += (Vector3) direccion * velocidad * Time.deltaTime;
        }
    }
}
