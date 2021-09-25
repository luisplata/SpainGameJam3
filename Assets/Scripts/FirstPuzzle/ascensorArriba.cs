using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ascensorArriba : MonoBehaviour
{
    public Transform door;
    public Transform toPosition;
    bool isPushing;
    float step = 0.01f;
    void Start()
    {

        isPushing=false;
    }
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            var player = other.gameObject.GetComponent<Player>().OnActionPlayerEvent += OnActionPlayerEvent;
        }
    }
    private void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            var player = other.gameObject.GetComponent<Player>().OnActionPlayerEvent -= OnActionPlayerEvent;
        }
    }
    void Update()
    {
        if(isPushing){
            door.position = Vector3.MoveTowards(door.position, toPosition.position, step);
        }

    }

    private void OnActionPlayerEvent(float speed)
    {
        isPushing=true;
    }
}
