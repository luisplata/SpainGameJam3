using UnityEngine;

public class OpenDoorCustom : DoSomething
{
    [SerializeField] private Animator _animator;
    [SerializeField] private string boolean;
    [SerializeField] private bool values;
    public override void Do()
    {
        _animator.SetBool(boolean, values);
    }
}