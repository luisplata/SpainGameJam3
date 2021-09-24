using System.Numerics;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    Transform target;
    Transform camera_tr;

    float speed = 0.9f;
    bool isOut = false; 

    void Start() {
        camera_tr = GameObject.FindGameObjectWithTag("Camera").GetComponent<Transform>();
        target = GameObject.FindGameObjectWithTag("targetCamera").GetComponent<Transform>();
    }
    void Update()
    {
        if(isOut){
            this.transform.position = UnityEngine.Vector3.Lerp(camera_tr.position,target.position,speed * Time.deltaTime);
        }
    }
        void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            isOut=false;

        }
    }
    void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.tag == "Player")
        {
            isOut=true;

        }
    }
}
