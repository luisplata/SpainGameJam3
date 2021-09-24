using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoubleButton : MonoBehaviour
{
    bool twoButtonOn=false;
    public GameObject door;
    public button1Hold button1;
    public button2Hold button2;

    void Start()
    {
        button1 = GameObject.Find("button1").GetComponent<button1Hold>();
        button2 = GameObject.Find("button2").GetComponent<button2Hold>();
    }
    void Update()
    {
        if(button1.buttonHold && button2.buttonHold){
            Destroy(door); 
        }
    }
}
