using UnityEngine;

public class GroundedState : BaseState
{
    public GroundedState(bool canMove, Rigidbody2D rigidbody, GroundChecker checker, PlayerMovementConfig config) : base(canMove, rigidbody, checker, config)
    {
    }


    public override void Update()
    {
        if (Input.GetButtonDown(Axis.Jump) && Checker.IsGrounded == true)
        {
            Jump();
        }
    }
    public override void Exit()
    {

    }

}
