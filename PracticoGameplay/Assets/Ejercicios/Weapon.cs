﻿using UnityEngine;

namespace Ejercicios
{
    public class Weapon : MonoBehaviour
    {
        public bool isTriggerPressed;

        public Cooldown reload;

        public Transform bulletAttachPoint;
        
        public GameObject bulletPrefab;

        private void FixedUpdate()
        {
            reload.current += Time.deltaTime;

            if (reload.isReady && isTriggerPressed)
            {
                var bulletObject = GameObject.Instantiate(bulletPrefab, bulletAttachPoint.position, bulletAttachPoint.rotation);
                bulletObject.GetComponent<Bullet>().Fire(transform.right);
                reload.Reset();
            }
        }
    }
}