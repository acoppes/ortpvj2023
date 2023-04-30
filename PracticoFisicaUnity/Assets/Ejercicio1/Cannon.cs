using UnityEngine;

namespace Ejercicio1
{
    public class Cannon : MonoBehaviour
    {
        public GameObject ballPrefab;
        public Transform attachPoint;

        public float impulsoDisparo;

        // Update is called once per frame
        void Update()
        {
            if (Input.GetMouseButtonDown(0))
            {
                var ballInstance= GameObject.Instantiate(ballPrefab);
                ballInstance.transform.position = attachPoint.position;

                var direction = attachPoint.transform.right;

                var body = ballInstance.GetComponent<Rigidbody2D>();
                body.AddForce(direction * impulsoDisparo, ForceMode2D.Impulse);
            }
        }
    }
}
