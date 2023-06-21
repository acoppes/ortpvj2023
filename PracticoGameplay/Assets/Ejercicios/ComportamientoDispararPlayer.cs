using UnityEngine;
using UnityEngine.Serialization;

namespace Ejercicios
{
    public class ComportamientoDispararPlayer : ComportamientoBase
    {
        public Collider2D detectorPlayer;
        
        public Cooldown cooldown;
        
        private Transform playerTransform;

        public Weapon weapon;

        public ComportamientoManager comportamientoManager;

        private Collider2D[] colliders = new Collider2D[1];
        
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

            var contactFilter2D = new ContactFilter2D()
            {
                useLayerMask = true,
                layerMask = LayerMask.GetMask("Player"),
                useTriggers = true
            };
            
            if (Physics2D.OverlapCollider(detectorPlayer, contactFilter2D, colliders) > 0)
            {
                playerTransform = colliders[0].transform;
                comportamientoManager.TomarControl(this);
            }
        }

        public override bool Run()
        {
            if (playerTransform == null)
            {
                return false;
            }

            weapon.aimPosition = playerTransform.position;
            weapon.isTriggerPressed = true;
            
            var contactFilter2D = new ContactFilter2D()
            {
                useLayerMask = true,
                layerMask = LayerMask.GetMask("Player"),
                useTriggers = true
            };
            
            if (Physics2D.OverlapCollider(detectorPlayer, contactFilter2D, colliders) == 0)
            {
                cooldown.Reset();
                playerTransform = null;
               // weapon.aimPosition = transform.position + new Vector3(1, 0, 0);
                weapon.isTriggerPressed = false;
                return false;
            }

            return true;
        }
    }
}