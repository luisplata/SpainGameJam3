using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SFX : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    public AudioClip fabrica;
    public AudioClip desierto;
    public AudioClip Bosque;
    public AudioClip madera;
    public int zona = 0;

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("AudioFabricaCueva"))
        {
            zona = 0;
        }
        if (other.CompareTag("AudioDesierto"))
        {
            zona = 1;
        }
        if (other.CompareTag("AudioBosque"))
        {
            zona = 2;
        }
        if (other.CompareTag("AudioMadera"))
        {
            zona = 3;
        }
        
    }

    
    public void SFXAndar()
    {
        if (zona == 0)
        {
            audioSource.clip = fabrica;
            audioSource.Play();
        }
        if (zona == 1)
        {
            audioSource.clip = desierto;
            audioSource.Play();
        }
        if (zona == 2)
        {
            audioSource.clip = Bosque;
            audioSource.Play();
        }
        if (zona == 3)
        {
            audioSource.clip = madera;
            audioSource.Play();
        }
    }
    public void SFXStop()
    {
        audioSource.Stop();
    }
}
