using System;
using UnityEngine;
using UnityEngine.Serialization;

namespace Ejercicios
{
    public class ComportamientoGrow : ComportamientoBase
    {
        [FormerlySerializedAs("comportamientoManage")] 
        [FormerlySerializedAs("enemigo")] 
        public ComportamientoManager comportamientoManager;
        
        public Cooldown duration;

        public Transform sprite;

        public AnimationCurve sizeCurve = AnimationCurve.Linear(0, 1, 1, 1.5f);

        public GameObject dividePrefab;
        
        public override void RunPassive()
        {
            duration.current += Time.deltaTime;

            var scale = sizeCurve.Evaluate(duration.normalizedTime);

            sprite.localScale = new Vector3(scale, scale, scale);

            if (duration.isReady)
            {
                comportamientoManager.TomarControl(this);
            }
        }

        public override bool Run()
        {
            if (!duration.isReady)
            {
                return false;
            }

            var parte1 = GameObject.Instantiate(dividePrefab, transform.position + new Vector3(0.25f, 0, 0), transform.rotation);
            var parte2 = GameObject.Instantiate(dividePrefab, transform.position + new Vector3(-0.25f, 0, 0), transform.rotation);

            var targetPosition = comportamientoManager.GetComponentInChildren<ComportamientoMoveToTarget>().targetPosition;

            parte1.GetComponentInChildren<ComportamientoMoveToTarget>().targetPosition = targetPosition + new Vector3(1, 0, 0);
            parte2.GetComponentInChildren<ComportamientoMoveToTarget>().targetPosition = targetPosition + new Vector3(-1, 0, 0);

            GameObject.Destroy(comportamientoManager.gameObject);
            
            return true;
        }
    }
}