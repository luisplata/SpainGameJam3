using UnityEngine;

public class OpenDoorWithComeBackCustom : OpenDoorWithComeBack
{
    [SerializeField] private string nameOfTrigger;
    [SerializeField] private bool values;
    public override void Do()
    {
        _animator.SetBool(nameOfTrigger, values);
    }

    public override void DoComeBack()
    {
        _animator.SetBool(nameOfTrigger, !values);
    }
}