using UnityEngine;

namespace Ejercicio1
{
    public class MagnetoController : MonoBehaviour
    {
        // Update is called once per frame
        void Update()
        {
            var mousePosition = Input.mousePosition;
            mousePosition = Camera.main.ScreenToWorldPoint(mousePosition);

            var p = transform.position;
            p.x = mousePosition.x;
            p.y = mousePosition.y;
            transform.position = p;
        }
    }
}
