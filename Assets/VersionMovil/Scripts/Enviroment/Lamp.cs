using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Lamp : MonoBehaviour
{
    [SerializeField] private LineRenderer lineRenderer;
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject originOfChain;
    [SerializeField] private List<GameObject> chains;
    private Stack<GameObject> listOfChain;

    private void Start()
    {
        listOfChain = new Stack<GameObject>();
        foreach (var chain in chains)
        {
            listOfChain.Push(chain);
        }
        lineRenderer.positionCount = listOfChain.Count;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        animator.SetTrigger("touch");
    }

    private void Update()
    {
        PrintLine();
    }
    
    private void PrintLine()
    {
        if (listOfChain.Count <= 0)
        {
            lineRenderer.positionCount = 0;
            return;
        }
        var countPosition = 0;
        if (listOfChain.Count > 0)
        {
            countPosition = listOfChain.Count;
        }
        var positions = new Vector3[countPosition + 1];

        var positionCount = 0;
        foreach (var chain in listOfChain)
        {
            positions[positionCount] = chain.transform.position;
            positionCount++;
        }
        lineRenderer.SetPositions(positions);
    }
}
