using UnityEngine;
using UnityEngine.UI;

namespace Ejercicios
{
    public class PowerIcon : MonoBehaviour
    {
        public Image image;

        public void UpdateFromAbility(Ability ability)
        {
            if (ability == null)
            {
                image.fillAmount = 1;
            }
            else
            {
                image.fillAmount = 1.0f - ability.charge.normalizedTime;
            }
        }
    }
}
