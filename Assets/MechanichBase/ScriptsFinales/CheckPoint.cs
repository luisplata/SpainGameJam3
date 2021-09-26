using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class CheckPoint : MonoBehaviour
{
    [SerializeField] private GameObject playerPosition, panelPosition;
    private void OnTriggerEnter2D(Collider2D other)
    {
        if (other.gameObject.TryGetComponent<Player>(out var player))
        {
            player.SetCheckPoint(this);
        }
    }

    public Vector3 GetPlayerPosition()
    {
        return playerPosition.transform.position;
    }

    public Vector3 GetPanelPosition()
    {
        return panelPosition.transform.position;
    }
}
