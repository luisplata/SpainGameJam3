using System;
using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;
using UnityEngine.InputSystem;

public class Menu : MonoBehaviour
{
    [SerializeField] private GameObject menu;
    [SerializeField] private TMP_InputField speedOfCableComeBack, jumpStrong, movementSpeed, maxLenghtBeforeBreakCable, maxCountOfPointsTheCable, comeBackCableSpeed, weightCable, 
    maxEnergy, uploadSpeed, downloadSpeed;

    [SerializeField] private Player player;
    [SerializeField] private SolarPanel solarPanel;
    [SerializeField] private PlayerControllerBase basePlayer;
    [SerializeField] private ChainOrigen origin;
    
    private bool isActive;

    private void Start()
    {
        isActive = true;
    }

    public void OnMenu(InputValue value)
    {
        menu.SetActive(isActive);
        isActive = !isActive;
    }
}
