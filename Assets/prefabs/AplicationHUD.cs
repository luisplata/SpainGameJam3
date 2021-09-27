using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AplicationHUD : MonoBehaviour
{
    [SerializeField] private Slider slider, slider2;
    [SerializeField] private Player player;
    [SerializeField] private SolarPanel panel;

    private void Start()
    {
        player.OnUpdateSliderAction += OnUpdateSliderAction;
        panel.OnUpdateSliderAction += OnUpdateSliderAction2;
    }

    private void OnUpdateSliderAction2(float porcentaje)
    {
        Debug.Log($"porcentaje panel {porcentaje}");
        slider2.value = porcentaje;
    }

    private void OnUpdateSliderAction(float porcentaje)
    {
        Debug.Log($"porcentaje {porcentaje}");
        slider.value = porcentaje;
    }

    public delegate void OnUpdateSlider(float porcentaje);
    
}
