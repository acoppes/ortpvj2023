using System;
using UnityEngine;

namespace Ejercicios
{
    public class HealthBar : MonoBehaviour
    {
        public Health health;

        public CanvasGroup canvasGroup;
        public Transform bar;

        private void Update()
        {
            canvasGroup.alpha = health.factor < 1 ? 1 : 0;
            bar.localScale = new Vector3(health.factor, 1, 1);
        }
    }
}