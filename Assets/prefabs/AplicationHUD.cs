using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
public class AplicationHUD : MonoBehaviour
{
    [SerializeField] private Slider slider;
    public delegate void OnUpdateSlider(float porcentaje);

}
