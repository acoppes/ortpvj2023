using UnityEngine;

namespace Ejercicio1
{
    public class Control : MonoBehaviour
    {
        public float velocidad;

        public Animator animator;

        public SpriteRenderer spriteRenderer;
        
        // Update is called once per frame
        void Update()
        {
            var horizontal = Input.GetAxis("Horizontal");
            var direccion = new Vector2(horizontal, 0);

            transform.position += (Vector3) direccion * velocidad * Time.deltaTime;

            var walking = Mathf.Abs(horizontal) > 0;
            
            animator.SetBool("walking", walking);
            
            if (walking)
            {
                spriteRenderer.flipX = horizontal < 0;
            }
        }
    }
}
