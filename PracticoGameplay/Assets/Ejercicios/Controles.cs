using UnityEngine;

namespace Ejercicios
{
    public class Controles : MonoBehaviour
    {
        public Personaje personaje;

        public void Update()
        {
            var x = Input.GetAxis("Horizontal");
            var y = Input.GetAxis("Vertical");

            personaje.movimiento.desiredDirection = new Vector2(x, y);
            
            personaje.weapon.isTriggerPressed = Input.GetButton("Fire1");
            personaje.weapon.aimPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
            
            if (personaje.ability != null)
            {
                personaje.ability.isTriggerPressed = Input.GetButton("Fire2");
            }
        }
    }
}