using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    public Slider slider;
    public Gradient fill;
    public Image fillColor;

    public void setup(int hp)
    {
        slider.maxValue = hp;
        slider.value = hp;
        fillColor.color = fill.Evaluate(1f);
    }


    public void setHealth(int health)
    {
        slider.value = health;
        fillColor.color = fill.Evaluate(slider.normalizedValue);
    }
}
