using System.Collections.Generic;
using UnityEngine;

namespace Ejercicios
{
    public class ComportamientoManager : MonoBehaviour
    {
        private List<ComportamientoBase> comportamientos = new List<ComportamientoBase>();

        public Transform comportamientosParent;
        public ComportamientoBase comportamiento;

        private Transform chasePlayerTransform;

        private void Awake()
        {
            comportamientosParent.GetComponentsInChildren(comportamientos);
        }

        private void FixedUpdate()
        {
            foreach (var comportamiento in comportamientos)
            {
                comportamiento.RunPassive();
            }   
            
            if (comportamiento != null)
            {
                if (!comportamiento.Run())
                {
                    comportamiento.isRunning = false;
                    comportamiento = null;
                }
            }
            else
            {
                foreach (var comportamiento in comportamientos)   
                {
                    if (comportamiento.Run())
                    {
                        this.comportamiento = comportamiento;
                        this.comportamiento.isRunning = true;
                        break;
                    }
                }   
            }
        }


        public void TomarControl(ComportamientoBase nuevoComportamiento)
        {
            if (comportamiento != null)
            {
                comportamiento.isRunning = false;
                comportamiento = null;
            }

            this.comportamiento = nuevoComportamiento;
            this.comportamiento.isRunning = true;
        }
    }
}