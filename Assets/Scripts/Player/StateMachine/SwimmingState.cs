using UnityEngine;

public class SwimmingState : BaseState
{
    public SwimmingState(bool canMove, Rigidbody2D rigidbody, GroundChecker checker, PlayerMovementConfig config) : base(canMove, rigidbody, checker, config)
    {

    }

    public override void Update()
    {
    }

    public override void Exit()
    {
    }
}
