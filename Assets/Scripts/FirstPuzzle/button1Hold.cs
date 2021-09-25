using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class button1Hold : MonoBehaviour
{
    public bool buttonHold;
    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Carga")|| other.gameObject.CompareTag("Caja")   )
        {
            buttonHold=true;
        }
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("Carga")|| other.gameObject.CompareTag("Caja") )
        {
            buttonHold =false;
        }
    }
}
