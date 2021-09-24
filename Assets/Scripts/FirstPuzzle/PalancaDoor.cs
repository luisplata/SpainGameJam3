using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PalancaDoor : MonoBehaviour
{
    public GameObject door;

    public Transform target;
    Transform camera_tr;

    void Start()
    {
        camera_tr = GameObject.FindGameObjectWithTag("Camera").GetComponent<Transform>();
    }
        IEnumerator waitForZoomOut(float time)
    {
        yield return new WaitForSeconds(time);
        
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

    void focusObject(){
        //StartCoroutine(waitForZoomOut());
    }

    private void OnActionPlayerEvent(float speed)
    {
        camera_tr.position = UnityEngine.Vector3.Lerp(camera_tr.position,target.position,speed * Time.deltaTime);
       
        Destroy(door);
    }
}
