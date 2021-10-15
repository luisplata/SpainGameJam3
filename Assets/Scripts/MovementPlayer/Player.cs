using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.InputSystem;

public class Player : MonoBehaviour
{
    [SerializeField] private float speed;
    [SerializeField] private float forceJump;
    [SerializeField] private PlayerControllerBase chainSystemPlayer;
    [SerializeField] private Animator animator;
    [SerializeField] private GameObject spriteRobot;
    public delegate void OnActionPlayer(float speed);
    public AplicationHUD.OnUpdateSlider OnUpdateSliderAction;


    public OnActionPlayer OnActionPlayerEvent;
    private Rigidbody2D rb2d;
    private Vector2 inputValue;
    private bool isJump;
    private bool IsPullPanel;
    private bool shutdown;

    [SerializeField] private float energyTotal;
    [SerializeField] private int energyMax;
    [SerializeField] private bool hasDownload = true;

    private float detaTimeLocal = 0;
    [SerializeField] private float pullHoldTime;
    private Vector2 speedTotal;
    private CheckPoint _checkPoint;
    [SerializeField] private float velocityOfDownload;
    [SerializeField] private float velocityOfLoad;
    [SerializeField] private SFX sound;

    private void Start()
    {
        rb2d = GetComponent<Rigidbody2D>();
        isJump = false;
        _isOn = true;
        chainSystemPlayer.OnActivate += OnActivate;
        energyTotal = energyMax;
        chainSystemPlayer.OnActivate += () =>
        {
            hasUpload = true;
            hasDownload = false;
        };
        chainSystemPlayer.OnInactivate += () =>
        {
            hasUpload = false;
            hasDownload = true;
        };
    }

    private void OnActivate()
    {
        animator.SetTrigger("cable");
    }

    private bool _isOn;
    private bool hasUpload;

    public void OnAction(InputValue value)
    {
        if (shutdown) return;
        if (_isOn)
        {
            IsOnPress();
        }
        else
        {
            IsOffPress();
        }
        animator.SetTrigger("accion");
    }
    public void OnEnvironment(InputValue value)
    {
        if (shutdown) return;
        Debug.Log("Press");
        OnActionPlayerEvent?.Invoke(5);
        animator.SetTrigger("boton");
    }

    private void IsOffPress()
    {
        CreateChainToOrigin();
        IsPullPanel = false;
        _isOn = true;
    }

    private void CreateChainToOrigin()
    {
        chainSystemPlayer.GetOrigin()?.GetComponent<SolarPanel>().BlockAll();
    }

    private void IsOnPress()
    {
        PullPanel();
        IsPullPanel = true;
        _isOn = false;
    }


    public void OnMove(InputValue value)
    {
        if (shutdown) return;
        var readValue = value.Get<Vector2>();
        Debug.Log(readValue);
        readValue.y = 0;
        inputValue = readValue;
        if (inputValue.x < 0 && spriteRobot.transform.localScale.x < 0)
        {
            var localScaleRobot = spriteRobot.transform.localScale;
            localScaleRobot.x = spriteRobot.transform.localScale.x * -1;
            spriteRobot.transform.localScale = localScaleRobot;
        }
        if (inputValue.x > 0 && spriteRobot.transform.localScale.x > 0)
        {
            var localScaleRobot = spriteRobot.transform.localScale;
            localScaleRobot.x = spriteRobot.transform.localScale.x * -1;
            spriteRobot.transform.localScale = localScaleRobot;
        }
    }

    public void OnJump(InputValue input)
    {
        IsOnPressJump();
    }

    private void IsOffPressJump()
    {
        isJump = false;
    }

    private void IsOnPressJump()
    {
        if (hasJumping) return;
        rb2d.velocity = Vector2.up * forceJump;
        Jumping();
    }

    private void Jumping()
    {
        //if (isJump) return;
        isJump = true;
        hasJumping = true;
        //rb2d.AddForce(Vector2.up * forceJump, ForceMode2D.Impulse);
    }

    public float FallMultipler;
    public float LowJumMultipler;
    private bool _isOnJump = true;
    private bool hasJumping;

    private void OnCollisionEnter2D(Collision2D other)
    {
        if (other.gameObject.CompareTag("Floor") || other.gameObject.CompareTag("Respawn"))
        {
            hasJumping = false;
            animator.SetBool("jump", false);
        }
    }

    private void FixedUpdate()
    {
        speedTotal = inputValue * Time.deltaTime * speed;

        if (speedTotal.sqrMagnitude > 1)
        {
            animator.SetBool("walk", true);
            if (!isJump)
            {
                sound?.SFXAndar();
            }
        }
        else
        {
            animator.SetBool("walk", false);
            sound?.SFXStop();
            speedTotal = Vector2.zero;
        }

        var beforeVelocity = speedTotal;
        beforeVelocity.y = rb2d.velocity.y;
        rb2d.velocity = beforeVelocity;
    }


    private void Update()
    {
        if (IsPullPanel)
        {
            detaTimeLocal += Time.deltaTime;
            if (detaTimeLocal > pullHoldTime)
            {
                detaTimeLocal = 0;
                //RemoveOnceChain();
            }
        }
        else
        {
            detaTimeLocal = 0;
        }

        if (hasDownload)
        {
            if (energyTotal > 0)
            {
                var ofDownload = (1 * velocityOfDownload);
                if (chainSystemPlayer.GetOrigin() != null)
                {
                    try
                    {
                        chainSystemPlayer.GetOrigin().GetEnergy(ofDownload);
                    }
                    catch (Exception)
                    {
                        energyTotal -= ofDownload;
                    }
                }
                else
                {
                    energyTotal -= ofDownload;
                }
            }
            else
            {
                energyTotal = 0;
            }
            OnUpdateSliderAction?.Invoke(energyTotal / energyMax);
        }

        if (hasUpload)
        {
            if (energyTotal <= energyMax)
            {
                var ofDownload = 1 * velocityOfLoad;
                if (chainSystemPlayer.GetOrigin() != null)
                {
                    try
                    {
                        energyTotal += chainSystemPlayer.GetOrigin().GetEnergy(ofDownload);
                    }
                    catch (Exception)
                    {
                        energyTotal -= ofDownload;
                    }
                }
                //energyTotal += chainSystemPlayer.GetOrigin()?.GetEnergy();
            }
            else
            {
                energyTotal = energyMax;
            }
            OnUpdateSliderAction?.Invoke(energyTotal / energyMax);
        }
        
        //jumping
        if (hasJumping)
        {
            if (isJump)
            {
                if (rb2d.velocity.y < 0)
                {
                    rb2d.velocity += Vector2.up * Physics2D.gravity.y * (FallMultipler -1) * Time.deltaTime;
                }
                chainSystemPlayer.GetOrigin()?.GetComponent<SolarPanel>().Jump();
                animator.SetBool("jump", true);
                sound?.SFXStop();
            }
            else
            {
                if (rb2d.velocity.y > 0)
                {
                    rb2d.velocity += Vector2.up * Physics2D.gravity.y * (FallMultipler -1) * Time.deltaTime;
                }
            }
        }
        
    }

    private void RemoveOnceChain()
    {
        chainSystemPlayer.GetOrigin()?.RemoveChain();
    }

    private void PullPanel()
    {
        chainSystemPlayer.GetOrigin()?.GetComponent<SolarPanel>().EnableAll(speedTotal);
    }

    public void SetCheckPoint(CheckPoint checkPoint)
    {
        _checkPoint = checkPoint;
    }

    public CheckPoint GetLastCheckPoint()
    {
        shutdown = false;
        spriteRobot.SetActive(true);
        return _checkPoint;
    }

    public void ShutDown()
    {
        shutdown = true;
        spriteRobot.SetActive(false);
    }

    public void SetVelocity(float velocity)
    {
        velocityOfLoad = velocity;
    }
}
