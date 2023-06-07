using UnityEngine;

namespace Ejercicios
{
    public class Controles : MonoBehaviour
    {
        public Movimiento movimiento;

        public Weapon weapon;
        
        public void Update()
        {
            var x = Input.GetAxis("Horizontal");
            var y = Input.GetAxis("Vertical");

            movimiento.desiredDirection = new Vector2(x, y);
            weapon.isTriggerPressed = Input.GetButton("Fire1");

            weapon.aimPosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);
        }
    }
}