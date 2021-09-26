using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ConsumerDoTwoSomething : MonoBehaviour
{
    [SerializeField] private DoReady readyOne,readyTwo;
    [SerializeField] private GameObject lightOne, lightTwo;
    [SerializeField] private Animator animator;
    private bool isInside = true;

    private void Update()
    {
        lightOne.SetActive(readyOne.IsReady);
        lightTwo.SetActive(readyTwo.IsReady);
        animator.SetBool("open", readyOne.IsReady && readyTwo.IsReady);
    }
}
