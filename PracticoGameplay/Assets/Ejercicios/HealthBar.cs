using UnityEngine;

namespace Ejercicios
{
    public class HealthBar : MonoBehaviour
    {
        public Health health;

        public CanvasGroup canvasGroup;
        public Transform bar;

        public Animator animator;

        public void OnDamage(float damage)
        {
            animator.SetTrigger("hit");
        }

        private void Update()
        {
            canvasGroup.alpha = health.factor < 1 ? 1 : 0;
            bar.localScale = new Vector3(health.factor, 1, 1);
        }
    }
}