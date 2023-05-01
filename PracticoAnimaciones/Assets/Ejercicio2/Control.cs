using UnityEngine;

namespace Ejercicio2
{
    public class Control : MonoBehaviour
    {
        public float velocidad;

        public Animator animator;

        // Update is called once per frame
        void Update()
        {
            var horizontal = Input.GetAxis("Horizontal");
            var direccion = new Vector2(horizontal, 0);

            transform.position += (Vector3) direccion * velocidad * Time.deltaTime;

            var walking = Mathf.Abs(horizontal) > 0;
            
            animator.SetBool("walking", walking);
        }
    }
}
