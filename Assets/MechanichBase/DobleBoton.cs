using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DobleBoton : MonoBehaviour
{
    [SerializeField] private ButtonCustom boton1, boton2;
    [SerializeField] private ActionButtonCustom actionGeneral;
    [SerializeField] private float timeMax;
    private float _deltaTimeLocal;
    private bool _isActioned;

    private void Update()
    {
        if (boton1.IsPress() && boton2.IsPress() && !_isActioned)
        {
            _deltaTimeLocal += Time.deltaTime;
            if (_deltaTimeLocal >= timeMax)
            {
                _deltaTimeLocal = 0;
                actionGeneral.OnAction();
                _isActioned = true;
            }
        }
    }
}