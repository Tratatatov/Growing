using UnityEngine;
[CreateAssetMenu(fileName = "PlayerConfig")]
public class PlayerMovementConfig : ScriptableObject
{
    [SerializeField] private float _speed;
    [SerializeField] private float _jumpHeight;
    [SerializeField] private float _knockForce;
    [SerializeField] private float _gravityScale;
    public float GravityScale => _gravityScale;
    public float Speed => _speed;
    public float JumpHeight => _jumpHeight;
    public float KnockForce => _knockForce;
}
