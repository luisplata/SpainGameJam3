using UnityEngine;
public class OpenDoor : DoSomething
{
    [SerializeField] private Animator _animator;
    public override void Do()
    {
        _animator.SetTrigger("open");
    }
}