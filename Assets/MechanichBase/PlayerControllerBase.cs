using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerBase : MonoBehaviour
{
    [SerializeField] private DistanceJoint2D distanceJoin;
    [SerializeField] private float maxDistance;
    private ChainOrigen origin;
    private bool hasCreate;
    private bool hasEvaluate;
    private Rigidbody2D _distanceJoinConnectedBody;

    public void Configure(ChainOrigen origen)
    {
        origin = origen;
    }

    // Update is called once per frame
    void Update()
    {
        if (DistanceInTwoObject() && hasEvaluate)
        {
            hasEvaluate = false;
            if (origin.CanCreateChain())
            {
                origin.CreatedChain();
            }
            else
            {
                distanceJoin.enabled = false;
                origin.CutChain();
            }
        }
    }

    private bool DistanceInTwoObject()
    {
        var distanceJoinConnectedBody = distanceJoin.connectedBody;
        if (distanceJoinConnectedBody == null) return false;
        var sqrMagnitude = (distanceJoinConnectedBody.transform.position - transform.position).sqrMagnitude;
        Debug.Log($"Distance is {sqrMagnitude}");
        return sqrMagnitude > maxDistance;
    }

    public void SetLastChain(Rigidbody2D lastChain)
    {
        distanceJoin.connectedBody = lastChain;
        
        distanceJoin.enabled = true;
        hasEvaluate = true;
        _distanceJoinConnectedBody = lastChain;
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Respawn"))
        {
            origin.CreatedChain();
        }
    }

    public void Evaluate()
    {
        hasEvaluate = true;
    }

    public ChainOrigen GetOrigin()
    {
        return origin;
    }
}
