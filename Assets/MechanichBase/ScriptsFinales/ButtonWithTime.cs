using System.Collections;
using UnityEngine;

public class ButtonWithTime : Button
{
    [SerializeField] private float timeToComeBack;
    protected override void OnActionPlayerEvent(float speed)
    {
        base.OnActionPlayerEvent(speed);
        StartCoroutine(ComeBackToAll());
    }

    IEnumerator ComeBackToAll()
    {
        while (isInside)
        {
            yield return new WaitForSeconds(0.3f);    
        }
        yield return new WaitForSeconds(timeToComeBack);
        _doSomething.DoComeBack();
    }
}