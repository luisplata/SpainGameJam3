using System;
using System.Collections;
using UnityEngine;

public class Button : MonoBehaviour
{
    [SerializeField] protected Animator anim;
    [SerializeField] protected DoSomething _doSomething;
    [SerializeField] protected bool needPlayer;
    protected bool isInside;
    private Player _player;

    protected void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player"))
        {
            anim.SetBool("touch", true);
            if (!isInside && other.gameObject.TryGetComponent<Player>(out var player))
            {
                _player = player;
                _player.OnActionPlayerEvent += OnActionPlayerEvent;
                isInside = true;
            }
        }

        if ((other.gameObject.CompareTag("GameController") || other.gameObject.CompareTag("Respawn")) && !needPlayer)
        {
            anim.SetBool("touch", true);
            isInside = true;
            StartCoroutine(DoAutomatic());
        }
    }

    IEnumerator DoAutomatic()
    {
        yield return new WaitForSeconds(.5f);
        if (isInside) OnActionPlayerEvent(1);
    }

    protected void OnTriggerExit2D(Collider2D other)
    {
        if (other.gameObject.CompareTag("Player") || other.gameObject.CompareTag("GameController") || other.gameObject.CompareTag("Respawn"))
        {
            anim.SetBool("touch", false);
            if (isInside && other.gameObject.TryGetComponent<Player>(out var player))
            {
                _player = player;
                _player.OnActionPlayerEvent -= OnActionPlayerEvent;
            }
            isInside = false;
        }
    }

    protected virtual void OnActionPlayerEvent(float speed)
    {
        _doSomething?.Do();
    }
}