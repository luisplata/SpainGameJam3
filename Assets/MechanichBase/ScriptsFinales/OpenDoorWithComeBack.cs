using UnityEngine;
public class OpenDoorWithComeBack : DoSomething
{
    [SerializeField] private Animator _animator;
    public override void Do()
    {
        _animator.SetBool("open", true);
    }

    public void DoAlter()
    {
        _animator.SetBool("open", false);
    }
}