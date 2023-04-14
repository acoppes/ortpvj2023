using System;
using UnityEngine;
using UnityEngine.UI;

namespace Ejercicio2
{
    public class Personaje : MonoBehaviour
    {
        [SerializeField]
        private Text text;

        [NonSerialized]
        public int monedas;

        public void UpdateMonedas(int monedas)
        {
            this.monedas = monedas;
            text.text = $"Monedas: {monedas}";
        }

        public void OnContactWithMoneda(Moneda moneda)
        {
            GameObject.Destroy(moneda.gameObject);
            UpdateMonedas(monedas + 1);
        }
    }
}