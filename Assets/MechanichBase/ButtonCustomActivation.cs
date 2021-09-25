using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ButtonCustomActivation : MonoBehaviour
{
    public delegate void OnActivation();
    public OnActivation OnActivate;
    public OnActivation OnInactivate;

    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("triger");
        if (other.gameObject.name == "activar" || other.CompareTag("Player"))
        {
            OnActivate?.Invoke();
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.name == "activar")
        {
            OnInactivate?.Invoke();
        }
    }
}
