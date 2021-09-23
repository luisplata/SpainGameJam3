using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CameraController : MonoBehaviour
{
    Transform player;
    Transform camera_tr;
    Vector3 CameraVector;
    Vector3 PlayerVector;
    float speed = 1f;

    void Start() {
        camera_tr = GameObject.FindGameObjectWithTag("Camera").GetComponent<Transform>();
        player = GameObject.FindGameObjectWithTag("Player").GetComponent<Transform>();

        CameraVector = new Vector3(camera_tr.position.x, camera_tr.position.y, camera_tr.position.z);
        PlayerVector = new Vector3(player.position.x, player.position.y, player.position.z);
    }

    void OnTriggerExit2D(Collider2D other)
    {
        //Vector3 cameraPosition = camera_tr;
        //Vector3 targetPosition = player.transform.position;

        if (other.gameObject.tag == "Player")
        {
            float step = speed * Time.deltaTime;
            this.transform.position = Vector3.MoveTowards(transform.position, player.position, step);
            //CameraVector = new Vector3(player.position.x,camera_tr.position.y,camera_tr.position.z);
           // Debug.Log(CameraVector);

        }
    }
}
