using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class musicaController : MonoBehaviour
{
    public AudioSource bosque;
    public AudioSource fabrica;
    public AudioSource desierto;
    public AudioSource cueva;
    private void OnTriggerEnter2D(Collider2D other)
    {

        if (other.gameObject.TryGetComponent<AudioSource>(out var listen))
        {
            listen.mute = false;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent<AudioSource>(out var listen))
        {
            listen.mute = true;
        }
    }
}
