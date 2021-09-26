using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SolarPanel : MonoBehaviour
{
    [SerializeField] private int maxEnergy;
    [SerializeField] private float energy;
    private bool isInsideInLight;
    private Rigidbody2D _rigi;
    private bool _itIsInFloor;
    private bool _playerSayBlock;
    private ChainOrigen _origen;
    private Vector2 speedGlobal;
    [SerializeField] private float forceJump;

    private void Start()
    {
        energy = maxEnergy;
        _rigi = GetComponent<Rigidbody2D>();
        _origen = GetComponent<ChainOrigen>();
    }

    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.CompareTag("Light"))
        {
            isInsideInLight = true;
        }
    }

    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.CompareTag("Light"))
        {
            isInsideInLight = false;
        }
    }

    private void Update()
    {
        if (!isInsideInLight)
        {
            if (energy > 0)
            {
                if(!_origen.IsConnector) energy -= 1;
            }
        }
        else
        {
            if (energy < maxEnergy)
            {
                energy += 1;   
            }
        }

        Block();
        speedGlobal.y = _rigi.velocity.y;
        _rigi.velocity = speedGlobal;
    }

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Floor"))
        {
            _itIsInFloor = true;
        }
    }

    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Floor"))
        {
            _itIsInFloor = false;
        }
    }

    private void OnCollisionStay(Collision other)
    {
        if (other.gameObject.CompareTag("Floor"))
        {
            _itIsInFloor = true;
        }
    }

    public void BlockAll()
    {
        speedGlobal = Vector2.zero;
        _playerSayBlock = true;
    }

    public void Block()
    {
        if (_itIsInFloor && _playerSayBlock)
        {
            _playerSayBlock = false;
            //_rigi.constraints = RigidbodyConstraints2D.FreezeAll;   
        }
    }

    public void EnableAll(Vector2 speed)
    {
        speedGlobal = speed;
        //_rigi.constraints = RigidbodyConstraints2D.None;
        //_rigi.constraints = RigidbodyConstraints2D.FreezeRotation;
    }

    public void Jump()
    {
        _rigi.AddForce(Vector2.up * forceJump,ForceMode2D.Impulse);
    }
}
