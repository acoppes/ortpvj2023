using System;

namespace Ejercicios
{
    [Serializable]
    public struct Cooldown
    {
        public float total;
        public float current;

        public bool isReady => current >= total;

        public float normalizedTime => current / total;

        public void Reset()
        {
            current = 0;
        }
    }
}