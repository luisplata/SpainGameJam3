using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button2Hold : MonoBehaviour
{
    public bool buttonHold;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Carga")  )
        {
            buttonHold=true;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Carga") )
        {
            buttonHold =false;
        }
    }
}
