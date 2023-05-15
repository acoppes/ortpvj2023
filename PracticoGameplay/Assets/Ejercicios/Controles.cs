using System;
using UnityEngine;

namespace Ejercicios
{
    public class Controles : MonoBehaviour
    {
        public Movimiento movimiento;
        
        public void Update()
        {
            var x = Input.GetAxis("Horizontal");
            var y = Input.GetAxis("Vertical");

            movimiento.desiredDirection = new Vector2(x, y);
        }
    }
}