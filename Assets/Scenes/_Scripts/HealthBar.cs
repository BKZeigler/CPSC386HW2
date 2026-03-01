using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    [SerializeField] private Slider slider; // the health bar slider

    public void UpdateHealthBar(float currentHealth, float maxHealth) // called when updating health bar is neccessary
    {
        slider.value = currentHealth / maxHealth; // current/max is ratio to fill
    }
}
