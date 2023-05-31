using System;
using Cinemachine;
using UnityEngine;

namespace Ejercicios
{
    public class TemblorListener : MonoBehaviour
    {
        public CinemachineVirtualCamera virtualCamera;

        public float min = 0;
        public float max = 10;

        public float multiplicador = 1.0f;

        private void Update()
        {
            var temblorSources = GameObject.FindGameObjectsWithTag("TemblorSource");

            var temblorTotal = 0.0f;

            foreach (var temblorSource in temblorSources)
            {
                temblorTotal += temblorSource.GetComponent<TemblorSource>().force;
            }
            
            var perlinNoise = virtualCamera.GetCinemachineComponent<CinemachineBasicMultiChannelPerlin>();
            perlinNoise.m_AmplitudeGain = Mathf.Clamp(temblorTotal, min, max) * multiplicador;
        }
    }
}