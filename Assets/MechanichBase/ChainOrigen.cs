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
    [SerializeField] private PlayerControllerBase _player;
    [SerializeField] private int maxChains;
    [SerializeField] private LineRenderer linesRender;
    private Rigidbody2D rb;
    
    private Stack<GameObject> listOfChain;

    private bool canCreateChain;
    private bool isCutLine;

    private void Start()
    {
        listOfChain = new Stack<GameObject>();
        linesRender.positionCount = listOfChain.Count;
        rb = GetComponent<Rigidbody2D>();
        rb.constraints = RigidbodyConstraints2D.None;
    }

    public void CreatedChain()
    {
        var instantiate = Instantiate(chainPrefab);
        var position = transform.position;
        instantiate.transform.position = position;
        if (listOfChain.Count > 0)
        {
            listOfChain.Peek().GetComponent<ChainController>().Configure(instantiate.GetComponent<Rigidbody2D>());
        }
        else
        {
            _player.SetLastChain(instantiate.GetComponent<Rigidbody2D>());
        }

        instantiate.GetComponent<ChainController>().Configure(GetComponent<Rigidbody2D>());
        
        listOfChain.Push(instantiate);
        _player.Evaluate();
        isCutLine = false;
        rb.constraints = RigidbodyConstraints2D.FreezeAll;
    }

    private void Update()
    {
        if (_player == null) return;
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
            positions[positionCount] = _player.transform.position;
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

    public void RemoveChain()
    {
        var deletingChain = listOfChain.Pop();
        if (listOfChain.Count <= 0) return;
        listOfChain.Peek().GetComponent<ChainController>().Configure(deletingChain.GetComponent<ChainController>().GetBody());
        Destroy(deletingChain);
    }

    public void Configure(PlayerControllerBase player)
    {
        _player = player;
    }
}
