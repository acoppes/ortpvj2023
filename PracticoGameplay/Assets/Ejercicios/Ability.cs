using UnityEngine;

namespace Ejercicios
{
    public abstract class Ability : MonoBehaviour
    {
        public bool isTriggerPressed;
        
        public Cooldown charge;

        public float porcentajeCargaParaComenzar;
        
        public float velocidadConsumo = 1.0f;
        public float velocidadRecuperacion = 0.5f;
        
        public bool isActive;
        
        private void FixedUpdate()
        {
            if (!isActive)
            {
                charge.Increase(Time.deltaTime * velocidadRecuperacion);

                var canStart = charge.normalizedTime > porcentajeCargaParaComenzar;
                
                if (canStart && isTriggerPressed)
                {
                    // prender el shield visual y el collider, hacer invulnerablee al player, etc
                    isActive = true;
                    OnAbilityStart();
                }
            }

            if (isActive)
            {
                charge.Increase(-Time.deltaTime * velocidadConsumo);
                
                if (!isTriggerPressed || charge.isEmpty)
                {
                    isActive = false;
                    OnAbilityCompleted();

                    if (charge.isEmpty)
                    {
                        GameObject.Destroy(gameObject);
                    }
                }
            }
        }

        public abstract void OnAbilitySet(Personaje personaje);
        
        protected abstract void OnAbilityStart();
        
        protected abstract void OnAbilityCompleted();
    }
}