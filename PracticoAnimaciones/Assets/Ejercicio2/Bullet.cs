using UnityEngine;

namespace Ejercicio2
{
    public class Bullet : MonoBehaviour
    {
        public float velocidad;

        public Vector3 direccion;
        
        // Update is called once per frame
        void Update()
        {
            transform.position += (Vector3) direccion * velocidad * Time.deltaTime;
        }
    }
}
