using UnityEngine;

namespace Ejercicio2
{
    public class Control : MonoBehaviour
    {
        public float velocidad;

        public Animator animator;

        public float chargeTime = 1;
        private float chargeCurrentTime;

        public float multiplicadorVelocidadDuranteCarga = 0.5f;

        // Update is called once per frame
        void Update()
        {
            var horizontal = Input.GetAxis("Horizontal");
            
            var direccion = new Vector2(horizontal, 0);
            var charging = Input.GetButton("Fire1");

            var velocidad = this.velocidad * (charging ? multiplicadorVelocidadDuranteCarga : 1.0f);

            transform.position += (Vector3) direccion * velocidad * Time.deltaTime;

            var walking = Mathf.Abs(horizontal) > 0;
            
            animator.SetBool("walking", walking);
            animator.SetBool("charging", charging);

            if (!charging)
            {
                chargeCurrentTime = 0;
            }
            
            if (walking)
            {
                transform.localEulerAngles = new Vector3(0, horizontal > 0 ? 0 : 180, 0);
            }

            chargeCurrentTime += Time.deltaTime;
        }
    }
}
