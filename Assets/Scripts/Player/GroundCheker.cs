using UnityEngine;

public class GroundChecker : MonoBehaviour
{
    public bool IsGrounded => _isGrounded;
    [SerializeField] private bool _isGrounded;
    private const string Ground = "Ground";
    private void OnTriggerStay2D(Collider2D collision)
    {
        if (collision.tag == Ground)
        {
            
            _isGrounded = true;
        }
    }
    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == Ground)
        {
            _isGrounded = false;
        }
    }
}
