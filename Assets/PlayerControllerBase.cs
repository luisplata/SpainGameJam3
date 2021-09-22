using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlayerControllerBase : MonoBehaviour
{
    [SerializeField] private DistanceJoint2D distanceJoin;
    [SerializeField] private WheelJoint2D wheelJoint;
    [SerializeField] private float maxDistance;
    private Rigidbody2D rg;
    private ChainOrigen origin;

    private bool hasCreate;
    private bool hasEvaluate;
    // Start is called before the first frame update
    void Start()
    {
        rg = GetComponent<Rigidbody2D>();
    }

    public void Configure(ChainOrigen origen)
    {
        origin = origen;
    }

    // Update is called once per frame
    void Update()
    {
        Debug.Log(distanceJoin.distance);
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.Translate(Vector2.left,Space.World);
        }
        
        if (Input.GetKeyDown(KeyCode.W))
        {
            transform.Translate(Vector2.up,Space.World);
        }
        
        if (Input.GetKeyDown(KeyCode.S))
        {
            transform.Translate(Vector2.down,Space.World);
        }
        
        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.Translate(Vector2.right,Space.World);
        }

        if (distanceJoin.distance > maxDistance && hasEvaluate)
        {
            //origin.CutChain();
            hasEvaluate = false;
            distanceJoin.distance = 1;
            if (origin.CanCreateChain())
            {
                origin.CreatedChain();
            }
            else
            {
                distanceJoin.enabled = false;
                wheelJoint.enabled = false;
                origin.CutChain();
            }
        }

        if (Input.GetKeyDown(KeyCode.Space))
        {
            hasCreate = true;
        }
    }

    public void SetLastChain(Rigidbody2D lastChain)
    {
        distanceJoin.connectedBody = lastChain;
        wheelJoint.connectedBody = lastChain;
        
        distanceJoin.enabled = true;
        wheelJoint.enabled = true;
        hasEvaluate = true;
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
}
