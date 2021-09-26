using UnityEngine;

public abstract class DoSomething : MonoBehaviour
{
    public abstract void Do();

    public virtual void DoComeBack(){}
}