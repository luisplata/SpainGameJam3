using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class triggerDerrumbe : MonoBehaviour
{
    public Animator piedrasAnimator;
    [SerializeField] private int countOfPass;
    [SerializeField] private int privatePass;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Player"))
        {
            privatePass++;
            if (privatePass >= countOfPass)
            {
                piedrasAnimator.SetBool("cae",true);   
            }
        }
    }
}
