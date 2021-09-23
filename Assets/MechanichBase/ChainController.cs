using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainController : MonoBehaviour
{
    private float maxDistance;
    private DistanceJoint2D _distanceJoint;
    private WheelJoint2D _wheelJoint;
    private SpringJoint2D springJoint2D;
    private Rigidbody2D _otherChain;

    private void Awake()
    {
        _distanceJoint = GetComponent<DistanceJoint2D>();
        _wheelJoint = GetComponent<WheelJoint2D>();
        springJoint2D = GetComponent<SpringJoint2D>();
    }

    public void Configure(Rigidbody2D after)
    {
        _otherChain = after;
        _distanceJoint.connectedBody = _otherChain;
        _wheelJoint.connectedBody = _otherChain;
        springJoint2D.connectedBody = _otherChain;
        //UpdateAngleOfChain();
    }

    // Update is called once per frame
    void Update()
    {
        //UpdateAngleOfChain();
    }

    private void UpdateAngleOfChain()
    {
        if (_otherChain == null) return;
        var dir = _otherChain.transform.position - transform.position;
        var angle = Mathf.Atan2(dir.y, dir.x) * Mathf.Rad2Deg;
        var wheelJointSuspension = new JointSuspension2D
        {
            angle = angle
        };
        _wheelJoint.suspension = wheelJointSuspension;
    }

    public Rigidbody2D GetBody()
    {
        return _otherChain;
    }
}
