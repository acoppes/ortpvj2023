using UnityEngine;

namespace Ejercicio3
{
    public class ControlAuto : MonoBehaviour
    {
        [SerializeField]
        private MovimientoAuto movimiento;
        
        void Update()
        {
            movimiento.rotate = 0;
            movimiento.forward = 0;

            if (Input.GetKey(KeyCode.A))
            {
                movimiento.rotate += 1;
            }
            
            if (Input.GetKey(KeyCode.D))
            {
                movimiento.rotate += -1;
            }
            
            if (Input.GetKey(KeyCode.W))
            {
                movimiento.forward += 1;
            }
            
            if (Input.GetKey(KeyCode.S))
            {
                movimiento.forward += -1;
            }
        }
    }
}
