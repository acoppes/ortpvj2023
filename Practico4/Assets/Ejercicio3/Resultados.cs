using System;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;

namespace Ejercicio3
{
    public class Resultados : MonoBehaviour
    {
        public static int monedasRecolectadas;

        [SerializeField]
        private Text textTotales;
        [SerializeField]
        private Text textRecolectadas;
        
        private void Awake()
        {
            var monedasTotales = PlayerPrefs.GetInt("Ejercicio3.Monedas", 0);
            
            textTotales.text = $"Totales: {monedasTotales}";
            textRecolectadas.text = $"Recolectadas: {monedasRecolectadas}";
        }

        public void OnRestartButton()
        {
            SceneManager.LoadScene("Ejercicio3");
        }

        public void OnExitButton()
        {
            Application.Quit();
        }
    }
}
