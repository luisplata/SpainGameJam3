using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ChainController : MonoBehaviour
{
    private DistanceJoint2D _distanceJoint;
    private WheelJoint2D _wheelJoint;

    private void Awake()
    {
        _distanceJoint = GetComponent<DistanceJoint2D>();
        _wheelJoint = GetComponent<WheelJoint2D>();
    }

    public void Configure(Rigidbody2D after, float angle)
    {
        _distanceJoint.connectedBody = after;
        _wheelJoint.connectedBody = after;
        var wheelJointSuspension = new JointSuspension2D
        {
            angle = angle
        };
        _wheelJoint.suspension = wheelJointSuspension;// .angle = angle;
    }

    // Update is called once per frame
    void Update()
    {
        
    }
}
