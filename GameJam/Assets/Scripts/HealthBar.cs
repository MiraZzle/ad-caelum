using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthBar : MonoBehaviour
{
    private Slider slider;
    //public Gradient fill;
    //public Image fillColor;

    private void Start()
    {
        slider = GetComponent<Slider>();
    }

    public void SetMaxHealth(int hp)
    {
        slider.maxValue = hp;
        slider.value = hp;
        //fillColor.color = fill.Evaluate(1f);
    }


    public void SetHealth(int health)
    {
        slider.value = health;
        //fillColor.color = fill.Evaluate(slider.normalizedValue);
    }
}
