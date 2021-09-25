using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class OpenAndCloseDoor : MonoBehaviour
{
    public GameObject doorOpen;
    public GameObject closeDoor;
    bool openDoor=false;
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

    private void OnActionPlayerEvent(float speed)
    {
        closeDoor.SetActive(true);
        doorOpen.SetActive(false);
    }
}
