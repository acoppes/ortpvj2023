using UnityEngine;

namespace Ejercicios
{
    public abstract class ComportamientoBase : MonoBehaviour
    {
        // public abstract void CheckRun();

        public bool isRunning;
        
        public abstract bool Run();

        public virtual void RunPassive()
        {
            
        }
    }
}