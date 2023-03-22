using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class EnergyBar : MonoBehaviour
{
    public Slider slider;
    public Gradient gradient;
    public Image fiil;

    public void SetEnergy(int energy)
    {
        slider.value = energy;
        fiil.color = gradient.Evaluate(slider.normalizedValue);
    }
    public void SetMaxEnergy(int energy)
    {
        slider.maxValue = energy;
        slider.value = energy;
        fiil.color = gradient.Evaluate(1f);
    }
}
