using UnityEngine;

public class AnimationsChange : MonoBehaviour
{
    private PlayerAnimation _playerAnimation;
    private Animator _animator;
    private string IsWalking = "IsWalking";
    private string IsGrounded = "IsGrounded";
    private string IsIdling = "IsIdling";

    private void Start()
    {
        _animator = GetComponent<Animator>();
        _playerAnimation = FindObjectOfType<PlayerAnimation>();
    }

    private void Update()
    {
        _animator.SetBool(IsWalking, _playerAnimation.IsWalking);
        _animator.SetBool(IsGrounded, _playerAnimation.IsGrounded);
        _animator.SetBool(IsIdling, _playerAnimation.IsIdling);
    }
}
