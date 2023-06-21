using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using UnityEngine.Serialization;

namespace Ejercicios
{
    public class BossComportamiento : ComportamientoBase
    {
        public Health health;

        public List<Health> healthHijos;

        public Personaje torretaIzquierda;
        public Personaje torretaDerecha;

        public override bool Run()
        {
            return false;
        }

        public override void RunPassive()
        {
            healthHijos.RemoveAll(h => h == null);
            health.invulnerable = healthHijos.Count(h => h.current > 0) > 0;
        }


    }
}