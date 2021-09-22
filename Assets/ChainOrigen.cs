using System;
using System.Collections;
using System.Collections.Generic;
using System.Linq;
using System.Security.Cryptography;
using UnityEngine;

public class ChainOrigen : MonoBehaviour
{
    [SerializeField] private GameObject chainPrefab;
    [SerializeField] private float velocityOfReturn;
    [SerializeField] private PlayerControllerBase player;
    [SerializeField] private int maxChains;
    [SerializeField] private LineRenderer linesRender;
    
    private Stack<GameObject> listOfChain;

    private bool canCreateChain;
    private bool isCutLine;

    private void Start()
    {
        listOfChain = new Stack<GameObject>();
        player.Configure(this);
        linesRender.positionCount = listOfChain.Count;
    }

    public void CreatedChain()
    {
        if (listOfChain.Count <= maxChains)
        {
            var instantiate = Instantiate(chainPrefab);
            var position = transform.position;
            var dir = player.transform.position - position;
            instantiate.transform.position = position;
            var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
            if (listOfChain.Count > 0)
            {
                listOfChain.Peek().GetComponent<ChainController>().Configure(instantiate.GetComponent<Rigidbody2D>(), angle);
            }
            else
            {
                player.SetLastChain(instantiate.GetComponent<Rigidbody2D>());
            }

            instantiate.GetComponent<ChainController>().Configure(GetComponent<Rigidbody2D>(), angle);
            
            listOfChain.Push(instantiate);
            player.Evaluate();
            isCutLine = false;
        }
    }

    private void Update()
    {
        PrintLine();
    }

    private void PrintLine()
    {
        if (listOfChain.Count <= 0)
        {
            linesRender.positionCount = 0;
            return;
        }
        var countPosition = 0;
        if (listOfChain.Count > 0)
        {
            countPosition = listOfChain.Count;
        }
        var positions = new Vector3[countPosition + 2];
        if (isCutLine)
        {
            positions = new Vector3[countPosition + 1];
        }

        var positionCount = 0;
        positions[positionCount] = transform.position;
        positionCount++;
        foreach (var chain in listOfChain)
        {
            positions[positionCount] = chain.transform.position;
            positionCount++;
        }
        linesRender.positionCount = listOfChain.Count + 1;
        if (!isCutLine)
        {
            linesRender.positionCount = listOfChain.Count + 2;
            positions[positionCount] = player.transform.position;
        }
        
        linesRender.SetPositions(positions);
    }

    public void CutChain()
    {
        isCutLine = true;
        StartCoroutine("DeletedChain");
    }

    IEnumerator DeletedChain()
    {
        while (listOfChain.Count >= 1)
        {
            yield return new WaitForSeconds(velocityOfReturn);
            Destroy(listOfChain.Pop());   
        }
    }

    public bool CanCreateChain()
    {
        return listOfChain.Count <= maxChains;
    }
}
