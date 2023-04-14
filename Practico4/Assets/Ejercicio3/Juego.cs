using Ejercicio2;
using UnityEngine;
using UnityEngine.SceneManagement;

namespace Ejercicio3
{
    public class Juego : MonoBehaviour
    {
        private int monedasJuego;
        
        private void Awake()
        {
            Resultados.monedasRecolectadas = 0;
            monedasJuego = FindObjectsOfType<Moneda>().Length;
        }

        private void Update()
        {
            var monedas = FindObjectsOfType<Moneda>();

            if (monedas.Length == 0)
            {
                Resultados.monedasRecolectadas = monedasJuego;
                SceneManager.LoadScene("Resultados");
            }
        }
    }
}
