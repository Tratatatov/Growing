using UnityEngine;

public class Eating : MonoBehaviour
{

    [SerializeField] private Animator _animator;
    private Collider2D _collider;
    private const string Eat = "Eat";
    public void EatAnimation()
    {
        _animator.SetTrigger(Eat);
    }

    private void Awake()
    {
        _collider = GetComponent<Collider2D>();
    }
    

    private void OnMouseDown()
    {
        _collider.enabled = false;
        EatAnimation();
    }
}
