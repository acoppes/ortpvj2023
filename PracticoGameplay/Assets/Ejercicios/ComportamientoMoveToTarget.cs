using UnityEngine;

namespace Ejercicios
{
    public class ComportamientoMoveToTarget : ComportamientoBase
    {
        public Vector3 targetPosition;

        public Movimiento movimiento;
        
        public override bool Run()
        {
            var distance = targetPosition - transform.position;
            var inTargetPosition = distance.sqrMagnitude < movimiento.minDistanceToTargetSqr;

            movimiento.desiredDirection = Vector2.zero;
            
            if (inTargetPosition)
            {
                return false;
            }
            
            movimiento.desiredDirection = distance.normalized;
            return true;
        }
    }
}