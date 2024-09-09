using System.Collections;
using System.Collections.Generic;
using System.Diagnostics;
using UnityEditor;
using UnityEngine;

public class SmallSwimmingState : SwimmingState
{
    public SmallSwimmingState(bool canMove, Rigidbody2D rigidbody, GroundChecker checker, PlayerMovementConfig config) : base(canMove, rigidbody, checker, config)
    {
    }
    public override void Update()
    {
        if (Input.GetButtonDown(Axis.Jump))
        {
            Jump();
        }
    }
}
