using UnityEngine;
public class ElevatorControll : DoSomething
{
    [SerializeField] private Animator _animator;
    [SerializeField] private GameObject panel, toPoint;
    public override void Do()
    {
        _animator.SetTrigger("up");
    }

    public void LeavePanel()
    {
        panel.transform.parent = null;
        panel.transform.position = toPoint.transform.localPosition;
    }
}