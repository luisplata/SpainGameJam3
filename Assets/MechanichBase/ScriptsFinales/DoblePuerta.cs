using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DoblePuerta : DoSomething
{
    [SerializeField] private Animator _animator;
    [SerializeField] private bool dorOpen;
    public override void Do()
    {
        dorOpen = !dorOpen;
        _animator.SetBool("open",dorOpen);
    }
}
