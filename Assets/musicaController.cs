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
        if (other.CompareTag("fabrica"))
        {
            fabrica.Play();
            desierto.Stop();
            bosque.Stop();
            cueva.Stop();
        }
        if (other.CompareTag("desierto"))
        {
            desierto.Play();
            fabrica.Stop();
            bosque.Stop();
            cueva.Stop();
        }
        if (other.CompareTag("cueva"))
        {
            cueva.Play();
            bosque.Stop();
            desierto.Stop();
            fabrica.Stop();
        }
        if (other.CompareTag("bosque"))
        {
            bosque.Play();
            fabrica.Stop();
            desierto.Stop();
            cueva.Stop();
        }
    }
}
