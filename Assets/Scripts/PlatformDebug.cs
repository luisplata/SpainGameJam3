using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlatformDebug : MonoBehaviour
{
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            var player = other.gameObject.GetComponent<Player>().OnActionPlayerEvent += OnActionPlayerEvent;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            var player = other.gameObject.GetComponent<Player>().OnActionPlayerEvent -= OnActionPlayerEvent;
        }
    }

    private void OnActionPlayerEvent(float speed)
    {
        Debug.Log($"Activaste la platafforma {speed}");
    }
}
