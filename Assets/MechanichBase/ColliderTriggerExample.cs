using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ColliderTriggerExample : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D other)
    {
        Debug.Log("triger");
    }
}
