using Ejercicio1;
using UnityEngine;

namespace Ejercicio2
{
    public class Trampa : MonoBehaviour
    {
        [SerializeField]
        private RectBounds bounds;

        [SerializeField]
        private SpriteRenderer spriteRenderer;

        [SerializeField]
        private Color playerDetectedColor, noPlayerColor;
        
        private void Update()
        {
            var player = GameObject.FindWithTag("Player");
            var playerBounds = player.GetComponent<RectBounds>();

            var collideWithPlayer = bounds.Collides(playerBounds);

            spriteRenderer.color = collideWithPlayer ? playerDetectedColor : noPlayerColor;
        }
    }
}