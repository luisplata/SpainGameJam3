using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ascensorBajarTimer : MonoBehaviour
{
    public Transform ascensor;
    public Transform toPosition;
    public Transform toUpPosition;

    bool isDown=false;
    bool isUp=true;
    float step = 0.01f;

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
        if(isDown){
            ascensor.position = Vector3.MoveTowards(ascensor.position, toPosition.position, step);
        }
        if(isUp){
            ascensor.position = Vector3.MoveTowards(ascensor.position, toUpPosition.position, step);
        }
    }
    IEnumerator waitTime(float time){
        isDown=true;
        isUp=false;
        yield return new WaitForSeconds(time);
        isDown=false;
        isUp=true;
    }

    private void OnActionPlayerEvent(float speed)
    {
        StartCoroutine(waitTime(8));
    }
}
