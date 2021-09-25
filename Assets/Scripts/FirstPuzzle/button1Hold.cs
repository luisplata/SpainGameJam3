using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Experimental.Rendering.Universal;

public class button1Hold : MonoBehaviour
{
    public bool buttonHold;
    public Light2D light2D1;

    void Start()
    {
        light2D1 = GameObject.Find("Light1").GetComponent<Light2D>();
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Carga")  )
        {
            buttonHold=true;
            light2D1.intensity=1;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Carga")  )
        {
            buttonHold =false;
            light2D1.intensity=0;
        }
    }
}
