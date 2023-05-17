using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Serialization;

namespace Ejercicios
{
    public class ComportamientoChasePlayer : ComportamientoBase
    {
        public Collider2D detectorPlayer;
        
        public Cooldown cooldown;
        public Cooldown stopCooldown;
        
        private Transform playerTransform;
        
        public Movimiento movimiento;

        [FormerlySerializedAs("comportamientoManage")] 
        [FormerlySerializedAs("enemigo")] 
        public ComportamientoManager comportamientoManager;

        public override void RunPassive()
        {
            if (isRunning)
            {
                return;
            }
            
            cooldown.current += Time.deltaTime;
            
            if (!cooldown.isReady)
            {
                return;
            }
            
            var playerColliders = new List<Collider2D>();
        
            var contactFilter2D = new ContactFilter2D()
            {
                useLayerMask = true,
                layerMask = LayerMask.GetMask("Player"),
                useTriggers = true
            };
            
            if (Physics2D.OverlapCollider(detectorPlayer, contactFilter2D, playerColliders) > 0)
            {
                playerTransform = playerColliders[0].transform;
                comportamientoManager.TomarControl(this);
            }
        }

        public override bool Run()
        {
            if (playerTransform == null)
            {
                return false;
            }
            
            movimiento.desiredDirection = Vector2.zero;
            
            stopCooldown.current += Time.deltaTime;
            
            var distance = playerTransform.position - transform.position;
            var inTargetPosition = distance.sqrMagnitude < movimiento.minDistanceToTargetSqr;
            
            if (!inTargetPosition && !stopCooldown.isReady)
            {
                movimiento.desiredDirection = distance.normalized;
                return true;
            }
            else
            {
                cooldown.Reset();
                stopCooldown.Reset();

                playerTransform = null;
                
                return false;
            }
        }
    }
}