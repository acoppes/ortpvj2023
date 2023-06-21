using UnityEngine;

namespace Ejercicios
{
    public class Shield : Ability
    {
        public GameObject shieldObject;
        public Personaje personaje;

        private void Awake()
        {
            shieldObject.SetActive(false);
        }

        public override void OnAbilitySet(Personaje personaje)
        {
            this.personaje = personaje;
        }

        protected override void OnAbilityStart()
        {
            shieldObject.SetActive(true);
            personaje.health.invulnerable = true;
        }

        protected override void OnAbilityCompleted()
        {
            shieldObject.SetActive(false);
            personaje.health.invulnerable = false;
        }
    }
}