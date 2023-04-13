using System;
using UnityEngine;

namespace Ejercicio1
{
    public class Selection : MonoBehaviour
    {
        [SerializeField]
        private RectBounds bounds;

        [SerializeField]
        private SpriteRenderer spriteRenderer;

        [SerializeField]
        private Color highlightedColor, selectedColor;
    
        [NonSerialized]
        public bool selected;

        public void Update()
        {
            if (bounds == null)
            {
                return;
            }
        
            var mousePosition = Camera.main.ScreenToWorldPoint(Input.mousePosition);

            var mouseInsideBounds = bounds.Collides(mousePosition);

            if (Input.GetMouseButtonDown(0))
            {
                selected = mouseInsideBounds;
            }

            if (selected)
            {
                spriteRenderer.color = selectedColor;
            }
            else
            {
                spriteRenderer.color = mouseInsideBounds ? highlightedColor : Color.white;
            }
        }
    }
}