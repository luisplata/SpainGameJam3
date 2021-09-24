using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DropObject : MonoBehaviour
{
    public Transform takeObjectPosition;
    public Transform boxObject;
    bool iTakeObject=false;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            var player = other.gameObject.GetComponent<Player>().OnActionPlayerEvent += OnActionPlayerEvent;
        }
    }
    private void OnCollisionExit2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            var player = other.gameObject.GetComponent<Player>().OnActionPlayerEvent -= OnActionPlayerEvent;
        }
    }

    private void OnActionPlayerEvent(float speed)
    {
        Debug.Log("ENTRO");
        iTakeObject=true;

    
    }

    void Update()
    {
        if(iTakeObject){
            boxObject.position = new Vector3(takeObjectPosition.position.x,takeObjectPosition.position.y,takeObjectPosition.position.z);
        }
        
    }
}
