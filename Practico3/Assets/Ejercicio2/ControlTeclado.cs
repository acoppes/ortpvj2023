using UnityEngine;

namespace Ejercicio2
{
    public class ControlTeclado : MonoBehaviour
    {
        [SerializeField]
        private string horizontalAxis = "Horizontal";
        
        [SerializeField]
        private string verticalAxis = "Vertical";

        [SerializeField]
        private Movimiento movimiento;
        
        void Update()
        {
            movimiento.direction.x = Input.GetAxis(horizontalAxis);
            movimiento.direction.y = Input.GetAxis(verticalAxis);
        }
    }
}
