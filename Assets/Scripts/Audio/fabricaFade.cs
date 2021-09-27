using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fabricaFade : MonoBehaviour
{
   
    float FadeTime = 0.25f;
    float startvolumen = 0f;

    AudioSource audioSource;

    void Start()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        audioSource.volume = startvolumen;
        
    }
   
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StopCoroutine("FadeOut");
            StartCoroutine("FadeIn");
        }
        if (startvolumen == 0)
        {
            startvolumen = 0.1f;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StopCoroutine("FadeIn");
            StartCoroutine("FadeOut");
        }
    }


    IEnumerator FadeIn()
    {   
        while (audioSource.volume < 1)
        {
            audioSource.volume += startvolumen * Time.deltaTime / FadeTime;

            yield return null;
        }

    }
    IEnumerator FadeOut ()
    {
        while (audioSource.volume > 0)
        {
            audioSource.volume -= startvolumen * Time.deltaTime / FadeTime;

            yield return null;
        }

    }
}
