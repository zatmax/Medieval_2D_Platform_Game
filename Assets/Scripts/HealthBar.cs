using UnityEngine;
using UnityEngine.UI;
public class HealthBar : MonoBehaviour
{ 
    public Slider slider;

    public Gradient gradient;
    public Image fill;
    public void SetMaxHealth (int health)
    {
        slider.maxValue = health;
        slider.value = health;

        fill.color = gradient.Evaluate(1f); //1 = tout à droite du gradient
    }

    public void SetHealth(int health)
    {
        slider.value = health;

        fill.color = gradient.Evaluate(slider.normalizedValue); //récupère valeur normalise au gradient entre 0 et 1
    }
}
