using UnityEngine;

namespace Ejercicios
{
    public class Weapon : MonoBehaviour
    {
        public bool isTriggerPressed;

        public Cooldown reload;

        public Transform pivot;
        public Transform bulletAttachPoint;
        
        public GameObject bulletPrefab;
        public GameObject bulletFxPrefab;

        public SpriteRenderer spriteRenderer;

        public Vector2 aimPosition;

        private void FixedUpdate()
        {
            if (pivot != null)
            {
                var p = (Vector2)pivot.transform.position;
                var direction = (aimPosition - p).normalized;

                var angle = Vector2.SignedAngle(Vector2.right, direction);
                pivot.rotation = Quaternion.Euler(0, 0, angle);

                spriteRenderer.flipY = angle > 90 || angle < -90;
            }
            
            reload.current += Time.deltaTime;

            if (reload.isReady && isTriggerPressed)
            {
                var bulletObject = GameObject.Instantiate(bulletPrefab, bulletAttachPoint.position, bulletAttachPoint.rotation);
                bulletObject.SetActive(true);
                bulletObject.GetComponent<Bullet>().Fire(bulletAttachPoint.right);
                reload.Reset();
                
                GameObject.Instantiate(bulletFxPrefab, bulletAttachPoint.position, bulletAttachPoint.rotation);
            }
        }

        public void SetWeapon(Weapon weapon)
        {
            reload = weapon.reload;
            bulletPrefab = weapon.bulletPrefab;
            bulletFxPrefab = weapon.bulletFxPrefab;
            spriteRenderer.sprite = weapon.spriteRenderer.sprite;
        }
    }
}