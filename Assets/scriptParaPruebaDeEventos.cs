using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class scriptParaPruebaDeEventos : MonoBehaviour
{
    [SerializeField] private AudioSource audioSource;
    [SerializeField] private AudioClip clip;

    public void SoundExamble()
    {
        audioSource.clip = clip;
    }
}
