using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerDerrumbe : MonoBehaviour
{
    public Animator piedrasAnimator;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            piedrasAnimator.SetBool("cae",true);
        }
    }
}
