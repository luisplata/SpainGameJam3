using System;
using UnityEngine;

public class ButtonCustom : MonoBehaviour
{
    [SerializeField] private ButtonCustomActivation activation;
    [SerializeField] private bool isActive; 

    private void Start()
    {
        activation.OnActivate += OnActivate;
        activation.OnInactivate += OnInactivate;
    }
    
    private void OnInactivate()
    {
        isActive = false;
    }

    private void OnActivate()
    {
        isActive = true;
    }

    public bool IsPress()
    {
        return isActive;
    }
}