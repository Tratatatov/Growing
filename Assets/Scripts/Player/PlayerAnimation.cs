using UnityEngine;

public class PlayerAnimation : MonoBehaviour
{
    [SerializeField] private AudioSource _stepSounds;
    [SerializeField] private GroundChecker _groundChecker;
    private bool _isIdling;
    private bool _isWalking;
    private bool _isAirborn;
    private bool _isGrounded;

    public bool IsIdling => _isIdling;
    public bool IsWalking => _isWalking;
    public bool IsAirborn => _isAirborn;
    public bool IsGrounded => _isGrounded;

    private void PlaySounds()
    {
        if (Input.GetAxisRaw(Axis.Horizontal)!=0 && _isGrounded)
        {
            _stepSounds.enabled = true;
        }
        else
        {
            _stepSounds.enabled = false;

        }
    }

    private void Update()
    {
        PlaySounds();
        _isGrounded = _groundChecker.IsGrounded;

        if (_isGrounded == true && Input.GetAxisRaw(Axis.Horizontal) > 0.1f || Input.GetAxisRaw(Axis.Horizontal) < - 0.1f)
        {
            _isWalking = true;
            _isIdling = false;
        }
        else
        {
            _isIdling = true; 
            _isWalking = false;

        }
        if (_isGrounded == false)
        {
            _isAirborn = true;
        }
        else
        {
            _isAirborn = true;
        }
    }

}
