using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BigSwimmingState : SwimmingState
{
    public BigSwimmingState(bool canMove, Rigidbody2D rigidbody, GroundChecker checker, PlayerMovementConfig config) : base(canMove, rigidbody, checker, config)
    {
    }

    public override void Update()
    {
        base.Update();
        if (Input.GetButtonDown(Axis.Jump) && Checker.IsGrounded == true)
        {
            Jump();
        }
    }
}
