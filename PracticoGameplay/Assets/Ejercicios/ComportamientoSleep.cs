using UnityEngine;

namespace Ejercicios
{
    public class ComportamientoSleep : ComportamientoBase
    {
        public Cooldown cooldown;
        
        public Movimiento movimiento;
        
        public ComportamientoMoveToTarget moveToTarget;

        public override bool Run()
        {
            cooldown.current += Time.deltaTime;
                
            movimiento.desiredDirection = Vector2.zero;
            
            if (cooldown.isReady)
            {
                cooldown.Reset();
                if (moveToTarget != null)
                {
                    moveToTarget.targetPosition = UnityEngine.Random.insideUnitCircle * 5f;
                }
                
                return false;
            }

            return true;
        }
    }
}