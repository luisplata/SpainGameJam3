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



    
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("AudioFabricaCueva"))
        {
            zona = 0;
            audioSource.clip = fabrica;
            audioSource.Play();
        }
        if (other.CompareTag("AudioDesierto"))
        {
            zona = 1;
            audioSource.clip = desierto;
            audioSource.Play();
        }
        if (other.CompareTag("AudioBosque"))
        {
            zona = 2;
            audioSource.clip = Bosque;
            audioSource.Play();
        }
        if (other.CompareTag("AudioMadera"))
        {
            zona = 3;
            audioSource.clip = madera;
            audioSource.Play();
        }

        SFXStop();
    }

    
    public void SFXAndar()
    {
        audioSource.mute = false;
    }

    public void SFXStop()
    {
        audioSource.mute = true;
    }
}
