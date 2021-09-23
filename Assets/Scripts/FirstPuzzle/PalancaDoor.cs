using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PalancaDoor : MonoBehaviour
{
    bool palancaActivada = false;

    void OnTriggerEnter2D(Collider2D other){
        Debug.Log("entro");
        if(other.gameObject.tag=="Palanca"){

            if (Input.GetKeyDown(KeyCode.E)){
                palancaActivada=true;
                Debug.Log(palancaActivada);
            }
        }

    }

    void Update()
    {
        if(palancaActivada){

        }
    }

}
