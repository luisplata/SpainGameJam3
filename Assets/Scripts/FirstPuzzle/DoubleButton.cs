using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleButton : MonoBehaviour
{
    bool twoButtonOn=false;
    public GameObject door;
    public button1Hold button1;
    public button1Hold button2;

    void Start()
    {
    }
    void Update()
    {
        if(button1.buttonHold && button2.buttonHold){
            Destroy(door);
        }
    }
}
