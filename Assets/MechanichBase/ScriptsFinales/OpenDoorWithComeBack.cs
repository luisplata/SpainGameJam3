using UnityEngine;
public class OpenDoorWithComeBack : DoSomething
{
    [SerializeField] protected Animator _animator;
    public override void Do()
    {
        _animator.SetBool("open", true);
    }

    public virtual void DoAlter()
    {
        _animator.SetBool("open", false);
    }
}