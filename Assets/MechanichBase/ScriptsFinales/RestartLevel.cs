using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartLevel : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private GameObject panel;

    public void RestartLevelAction()
    {
        var lastCheckPoint = player.GetLastCheckPoint();
        player.gameObject.transform.position = lastCheckPoint.GetPlayerPosition();
        panel.transform.position = lastCheckPoint.GetPanelPosition();
    }
}
