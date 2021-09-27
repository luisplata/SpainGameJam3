using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using UnityEngine.UI;
public class AplicationHUD : MonoBehaviour
{
    [SerializeField] private Slider slider, slider2;
    [SerializeField] private Player player;
    [SerializeField] private SolarPanel panel;
    [SerializeField] private Animator ani;
    [SerializeField] private Animator ani2;
    [SerializeField] private List<GameObject> huds;

    private void Start()
    {
        player.OnUpdateSliderAction += OnUpdateSliderAction;
        panel.OnUpdateSliderAction += OnUpdateSliderAction2;
    }

    public void RestartGame()
    {
        SceneManager.LoadScene(0);
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
        if (porcentaje <= 0)
        {
            StartCoroutine(Hurry());
        }
    }

    IEnumerator Hurry()
    {
        ani2.SetBool("WillDied",true);
        yield return new WaitForSeconds(5);
        if (slider.value <= 0)
        {
            ani.SetTrigger("died");
        }
        else
        {
            ani2.SetBool("WillDied", false);
        }
    }

    public delegate void OnUpdateSlider(float porcentaje);

    public void StopAll()
    {
        player.OnUpdateSliderAction -= OnUpdateSliderAction;
        panel.OnUpdateSliderAction -= OnUpdateSliderAction2;
        foreach (var hud in huds)
        {
            hud.SetActive(false);   
        }
    }
}
