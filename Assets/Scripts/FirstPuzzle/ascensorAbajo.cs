using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ascensorAbajo : MonoBehaviour
{
    public Transform door;
    public Transform toPosition;
    public bool isDown;
    float step = 0.01f;
    public ascensorArriba aArriba;
    void Start()
    {
        isDown=false;
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
        if(isDown && !aArriba.isPushing){
            door.position = Vector3.MoveTowards(door.position, toPosition.position, step);
        }
        else{

        }

    }

    private void OnActionPlayerEvent(float speed)
    {
        isDown=true;
        aArriba.isPushing=false;
    }
}
