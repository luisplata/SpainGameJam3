using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarPanel : MonoBehaviour
{
    [SerializeField] private int maxEnergy;
    [SerializeField] private float energy;
    private bool isInsideInLight;

    private void Start()
    {
        energy = 100;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Light"))
        {
            isInsideInLight = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Light"))
        {
            isInsideInLight = false;
        }
    }

    private void Update()
    {
        if (!isInsideInLight)
        {
            energy -= 1;
        }
        else
        {
            if (energy < maxEnergy)
            {
                energy += 1;   
            }
        }
    }
}
