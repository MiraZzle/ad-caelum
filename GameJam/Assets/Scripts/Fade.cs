using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class Fade : MonoBehaviour
{
    public Slider slider;

    public void setupFade(int hp)
    {
        slider.maxValue = hp;
        slider.value = hp;
    }


    public void setHealthFade(int health)
    {
        slider.value = health;
    }
}
