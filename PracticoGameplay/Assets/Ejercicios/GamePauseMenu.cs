using System;
using UnityEngine;
using UnityEngine.UI;

namespace Ejercicios
{
    public class GamePauseMenu : MonoBehaviour
    {
        public Slider slider;

        public GameObject canvasObject;
        
        private void Awake()
        {
            canvasObject.SetActive(false);
            slider.onValueChanged.AddListener(OnSliderChanged);

            var temblorListener = FindObjectOfType<TemblorListener>();
            if (temblorListener != null)
            {
                slider.SetValueWithoutNotify(temblorListener.multiplicador);
            }
        }
        
        public void OnSliderChanged(float value)
        {
            var temblorListener = FindObjectOfType<TemblorListener>();
            temblorListener.multiplicador = value;
        }

        public void OnClose()
        {
            Time.timeScale = 1;
            canvasObject.SetActive(false);
        }
        
        public void OnExit()
        {
            Application.Quit();
        }

        public void Open()
        {
            Time.timeScale = 0;
            canvasObject.SetActive(true);
        }
    }
}