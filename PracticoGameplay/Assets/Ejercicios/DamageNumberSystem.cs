using TMPro;
using UnityEngine;

namespace Ejercicios
{
    public class DamageNumberSystem : MonoBehaviour
    {
        public GameObject damageNumberPrefab;
        
        private void OnEnable()
        {
            EventosGenerales.onPersonajeDamaged += OnAnyPersonajeDamaged;
        }
        
        private void OnDisable()
        {
            EventosGenerales.onPersonajeDamaged -= OnAnyPersonajeDamaged;
        }

        private void OnAnyPersonajeDamaged(GameObject personaje, float damage)
        {
            var healthBar = personaje.transform.Find("HealthBar");

            GameObject numberInstance;
            if (healthBar != null)
            {
                numberInstance = GameObject.Instantiate(damageNumberPrefab, healthBar.position, Quaternion.identity);
            }
            else
            {
                numberInstance = GameObject.Instantiate(damageNumberPrefab, personaje.transform.position, Quaternion.identity);
            }

            if (numberInstance != null)
            {
                numberInstance.GetComponentInChildren<TextMeshProUGUI>().SetText($"{damage:0}");
                
                var random = UnityEngine.Random.insideUnitCircle * 0.5f;
                numberInstance.transform.position += (Vector3) random;
                LeanTween.alphaCanvas(numberInstance.GetComponent<CanvasGroup>(), 0, 0.2f);
                LeanTween.moveY(numberInstance, numberInstance.transform.position.y + 1, 0.25f).setDestroyOnComplete(true);
            }
            
        }
    }
}