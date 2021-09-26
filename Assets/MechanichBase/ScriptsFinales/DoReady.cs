using System.Collections;
using UnityEngine;
public class DoReady : DoSomething
{
    [SerializeField] private bool isReady;

    public bool IsReady => isReady;
    public override void Do()
    {
        isReady = true;
    }

    public override void DoComeBack()
    {
        base.DoComeBack();
        isReady = false;
    }
}