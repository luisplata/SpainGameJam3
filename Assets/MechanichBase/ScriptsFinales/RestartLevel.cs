using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class RestartLevel : MonoBehaviour
{
    [SerializeField] private Player player;
    [SerializeField] private GameObject playerObject;
    [SerializeField] private GameObject panel;

    public void RestartLevelAction()
    {
        var lastCheckPoint = player.GetLastCheckPoint();
        var transformLocalPosition = lastCheckPoint.GetPlayerPosition();
        transformLocalPosition.z = 0;
        playerObject.transform.localPosition = transformLocalPosition;
        var panelPosition = lastCheckPoint.GetPanelPosition();
        panelPosition.z = 0;
        panel.transform.localPosition = panelPosition;
    }
}
