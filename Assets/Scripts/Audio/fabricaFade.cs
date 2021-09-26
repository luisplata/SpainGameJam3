using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class fabricaFade : MonoBehaviour
{
    public float FadeTime = 1.0f;

    AudioSource audioSource;

    void Awake()
    {
        audioSource = gameObject.GetComponent<AudioSource>();
        
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine("FadeIn");
            StopCoroutine("FadeOut");
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            StartCoroutine("FadeOut");
            StopCoroutine("FadeIn");
        }
    }


    IEnumerator FadeIn()
    {
        float startVolume = audioSource.volume;

        if (startVolume == 0)
        {
            startVolume = 0.1f;
        }
        while (audioSource.volume < 1)
        {
            audioSource.volume += startVolume * Time.deltaTime / FadeTime;

            yield return null;
        }

    }
    IEnumerator FadeOut ()
    {
        float startVolume = audioSource.volume;

        while (audioSource.volume > 0)
        {
            audioSource.volume -= startVolume * Time.deltaTime / FadeTime;

            yield return null;
        }

    }
}
