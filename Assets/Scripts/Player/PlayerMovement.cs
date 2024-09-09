using UnityEngine;

[RequireComponent(typeof(Rigidbody2D))]
public class PlayerMovement : MonoBehaviour
{
    private Rigidbody2D _rigidbody;

    //States
    private GroundedState _groundedState;
    private SwimmingState _smallSwimmingState;
    private SwimmingState _mediumSwimmingState;
    private SwimmingState _bigSwimmingState;
    private BaseState _currentState;
    private PlayerSizeChanger _playerSizeChanger;
    [SerializeField] private States _currentStateSwitcher;
    [SerializeField] private GameObject _waterParticles;
    [SerializeField] private float _knockForce;
    [SerializeField] private float _knockBackForce;
    [SerializeField] private float _knockTime;

    [Header("Ground")]
    [SerializeField] private GroundChecker _groundChecker;
    [SerializeField] private PlayerMovementConfig _playerGroundedConfig;

    [Header("Swim")]
    [SerializeField] private PlayerMovementConfig _smallPlayerConfig;
    [SerializeField] private PlayerMovementConfig _mediumPlayerConfig;
    [SerializeField] private PlayerMovementConfig _bigPlayerConfig;
    private const string Water = "Water";
    private const string Ground = "Ground";
    private bool _isGrounded;
    private bool _canMove = true;
    public bool CanMove() => _canMove;

    private void ChangeState()
    {
        switch (_currentStateSwitcher)
        {
            case States.Grounded:
                _currentState = _groundedState;
                _currentState.Enter();

                break;
            case States.SwimmingSmall:
                _currentState = _smallSwimmingState;
                _currentState.Enter();

                break;
            case States.SwimmingMed:
                _currentState = _mediumSwimmingState;
                _currentState.Enter();

                break;
            case States.SwimmingBig:
                _currentState = _bigSwimmingState;
                _currentState.Enter();

                break;
        }
    }

    private void InitializeStates()
    {
        _groundedState = new GroundedState(CanMove(), _rigidbody, _groundChecker, _playerGroundedConfig);
        _smallSwimmingState = new SmallSwimmingState(CanMove(), _rigidbody, _groundChecker, _smallPlayerConfig);
        _mediumSwimmingState = new MediumSwimmingState(CanMove(), _rigidbody, _groundChecker, _mediumPlayerConfig);
        _bigSwimmingState = new BigSwimmingState(CanMove(), _rigidbody, _groundChecker, _bigPlayerConfig);
    }

    private void KnockUp()
    {
        _rigidbody.velocity = new Vector2(_rigidbody.velocity.x, 0);
        _rigidbody.AddForce(Vector2.up * _knockForce, ForceMode2D.Impulse);
    }

    private void Turning()
    {
        if (Input.GetKeyDown(KeyCode.A))
        {
            transform.rotation = Quaternion.Euler(0, 180, 0);
        }
        if (Input.GetKeyDown(KeyCode.D))
        {
            transform.rotation = Quaternion.Euler(0, 0, 0);

        }
    }

    private void KnockBackUp()
    {
        _rigidbody.velocity = Vector2.zero;
        Vector2 direction = new Vector2(-transform.right.x, 1).normalized;
        _rigidbody.AddForce(direction * _knockBackForce, ForceMode2D.Impulse);
    }
    private void TurnOffControl()
    {
        _canMove = false;
        Invoke("TurnOnControl", _knockTime);
    }
    private void TurnOnControl()
    {
        _canMove = true;
    }
    private void SetKinematic()
    {
        _rigidbody.isKinematic = true;
        Invoke(nameof(TurnOffKinematic), _knockTime);
    }
    private void TurnOffKinematic()
    {
        _rigidbody.isKinematic = false;
    }

    private void SwitchStateToSwim()
    {
        switch (_playerSizeChanger.SizeIndex)
        {
            case 0:
                _currentStateSwitcher = States.SwimmingSmall;
                break;
            case 1:
                _currentStateSwitcher = States.SwimmingMed;
                break;
            case 2:
                _currentStateSwitcher = States.SwimmingBig;
                break;
        }

    }

    private void Awake()
    {
        _rigidbody = GetComponent<Rigidbody2D>();
        _playerSizeChanger = GetComponent<PlayerSizeChanger>();
        InitializeStates();
        _currentState = _groundedState;
        _currentState.Enter();
    }

    private void Start()
    {
        EventBus.Instance.OnKnockUp.AddListener(KnockUp);
        EventBus.Instance.OnPlayerDamage.AddListener(KnockBackUp);
        EventBus.Instance.OnPlayerDamage.AddListener(TurnOffControl);
        EventBus.Instance.OnGameOver.AddListener(TurnOffControl);
        EventBus.Instance.OnGameOver.AddListener(SetKinematic);
    }

    private void OnTriggerExit2D(Collider2D collision)
    {
        if (collision.tag == Water)
            _currentStateSwitcher = States.Grounded;
    }

    private void Update()
    {
        _currentState.Update();
        Turning();
        ChangeState();
    }

    private void FixedUpdate()
    {
        _currentState.FixedUpdate();
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == Water)
        {
            Instantiate(_waterParticles, transform.position, Quaternion.identity);
            SwitchStateToSwim();
        }
    }

}
