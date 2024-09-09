using UnityEngine;

public class Water : MonoBehaviour
{
    [SerializeField] private Rigidbody2D _rigidbody;
    [SerializeField] private float _gravityScaleSmall = -0.1f;
    [SerializeField] private float _gravityScaleMedium = 0.5f;
    private const string Small = "Small";
    private const string Medium= "Medium";

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<Rigidbody2D>() != null)
        {
            _rigidbody = collision.GetComponent<Rigidbody2D>();
            _rigidbody.velocity = Vector2.zero;
        }
    }

    private void OnTriggerStay2D(Collider2D collision)
    {
        if (_rigidbody.tag == Small)
        {
            _rigidbody.gravityScale = _gravityScaleSmall;
        }
        if (collision.tag == Medium)
        {
            _rigidbody.gravityScale = _gravityScaleMedium;
        }
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        _rigidbody.gravityScale = 1;
    }
}
