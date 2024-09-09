using UnityEngine;

public abstract class BaseState
{
    protected Rigidbody2D Rigidbody;
    protected PlayerMovementConfig Config;
    protected GroundChecker Checker;
    protected bool CanMove;
    protected float JumpHeight;
    protected float Speed;
    protected float GravityScale;

    public BaseState(bool canMove, Rigidbody2D rigidbody, GroundChecker checker, PlayerMovementConfig config)
    {
        Config = config;
        CanMove = canMove;
        Rigidbody = rigidbody;
        Checker = checker;
        Speed = config.Speed;
        JumpHeight = config.JumpHeight;
        GravityScale = config.GravityScale;
    }


    public abstract void Update();
    public abstract void Exit();

    public void Enter()
    {
        ChangeGravityScale(GravityScale);
    }
    public void FixedUpdate()
    {
        Move();
    }

    protected void Jump()
    {
        if (CanMove == false) return;
        Rigidbody.AddForce(Vector2.up * JumpHeight, ForceMode2D.Impulse);
    }

    private void ChangeGravityScale(float scale)
    {
        Rigidbody.gravityScale = scale;
    }

    private void Move()
    {
        if (CanMove == false) return;
        Vector2 velocity = new Vector2(Input.GetAxis(Axis.Horizontal) * Speed, Rigidbody.velocity.y);
        Rigidbody.velocity = velocity;
    }

}
