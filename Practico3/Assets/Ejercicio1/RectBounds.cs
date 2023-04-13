using UnityEngine;

namespace Ejercicio1
{
    public class RectBounds : MonoBehaviour
    {
        [SerializeField]
        private float width, height;

        public Vector2 size => new Vector2(width * transform.localScale.x, height * transform.localScale.y);

        public Bounds GetBounds()
        {
            var p = transform.position;
            return new Bounds(
                p.x - size.x * 0.5f, 
                p.x + size.x * 0.5f, 
                p.y - size.y * 0.5f, 
                p.y + size.y * 0.5f);
        }
    
        public void OnDrawGizmos()
        {
            Gizmos.color = Color.green;
            Gizmos.DrawWireCube(transform.position, size);
        }

        public bool Collides(Vector2 point)
        {
            var bounds = GetBounds();

            if (point.x < bounds.xmin)
                return false;
        
            if (point.x > bounds.xmax)
                return false;
        
            if (point.y < bounds.ymin)
                return false;
       
            if (point.y > bounds.ymax)
                return false;
        
            return true;
        }
        
        public bool Collides(RectBounds rect)
        {
            var bounds = GetBounds();
            var rectBounds = rect.GetBounds();

            if (bounds.xmax < rectBounds.xmin)
                return false;
        
            if (bounds.xmin > rectBounds.xmax)
                return false;
            
            if (bounds.ymax < rectBounds.ymin)
                return false;
        
            if (bounds.ymin > rectBounds.ymax)
                return false;

            return true;
        }
    }
}