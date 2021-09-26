using System.Collections;
using UnityEngine;

public class ButtonWithComeBack : Button
{
    [SerializeField] private bool isActivate;
    private OpenDoorWithComeBack doSomething;
    protected override void OnActionPlayerEvent(float speed)
    {
        base.OnActionPlayerEvent(speed);
        isActivate = !isActivate;
        if (isActivate)
        {
            _doSomething.Do();
        }
        else
        {
            doSomething = (OpenDoorWithComeBack)_doSomething;
            doSomething.DoAlter();
        }
    }
}