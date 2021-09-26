using UnityEngine;

public class OpenDoorCustom : DoSomething
{
    [SerializeField] private Animator _animator;
    [SerializeField] private string trigger;
    public override void Do()
    {
        _animator.SetTrigger(trigger);
    }
}