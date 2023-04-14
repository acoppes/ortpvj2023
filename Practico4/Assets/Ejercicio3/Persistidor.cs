using Ejercicio2;
using UnityEngine;

namespace Ejercicio3
{
    public class Persistidor : MonoBehaviour
    {
        [SerializeField]
        private Personaje personaje;

        private void Awake()
        {
            var monedasGuardadas = PlayerPrefs.GetInt("Ejercicio3.Monedas", 0);
            personaje.UpdateMonedas(monedasGuardadas);
        }

        public void OnContactWithMoneda(Moneda moneda)
        {
            PlayerPrefs.SetInt("Ejercicio3.Monedas", personaje.monedas);
            PlayerPrefs.Save();
        }
    }
}
