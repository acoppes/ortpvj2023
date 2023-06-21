using System;
using UnityEngine;

namespace Ejercicios
{
    [Serializable]
    public struct Cooldown
    {
        public float total;
        public float current;

        public bool isReady => current >= total;

        public bool isEmpty => current <= 0;

        public float normalizedTime => current / total;

        public void Increase(float dt)
        {
            current = Mathf.Clamp(current + dt, 0, total);
        }

        public void Reset()
        {
            current = 0;
        }
    }
}