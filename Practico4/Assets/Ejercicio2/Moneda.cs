using UnityEngine;

namespace Ejercicio2
{
    public class Moneda : MonoBehaviour
    {
        [SerializeField]
        private CircleBounds bounds;
        
        private void FixedUpdate()
        {
            var playerObject = GameObject.FindWithTag("Player");
            var circleBounds = playerObject.GetComponent<CircleBounds>();

            if (bounds.InContact(circleBounds))
            {
                playerObject.BroadcastMessage("OnContactWithMoneda", this);
            }
        }
    }
}