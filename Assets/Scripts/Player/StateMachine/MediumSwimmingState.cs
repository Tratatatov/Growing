using UnityEngine;

public class MediumSwimmingState : SwimmingState
{
    public MediumSwimmingState(bool canMove, Rigidbody2D rigidbody, GroundChecker checker, PlayerMovementConfig config) : base(canMove, rigidbody, checker, config)
    {
    }
    public override void Update()
    {
        if (Input.GetButtonDown(Axis.Jump))
        {
            Rigidbody.velocity = Vector2.zero;
            Jump();
        }
    }


}
