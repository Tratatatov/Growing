using UnityEngine;

public class PlayerHp : MonoBehaviour
{
    [SerializeField] private int _startHp = 1;
    [SerializeField] private int _maxHp = 3;
    [SerializeField] private float _immortalityTime = 0.5f;
    private bool _canGetDamage = true;
    private int _hp;
    private void Start()
    {
        EventBus.Instance.OnPlayerDamage.AddListener(TakeDamage);
        EventBus.Instance.OnPlayerDamage.AddListener(Immortality);
        EventBus.Instance.OnIncreaseSize.AddListener(IncreaseHp);
        _hp = _startHp;

    }
    private void IncreaseHp()
    {
        if (_hp < _maxHp)
        {
            _hp++;
        }
    }
    private void Immortality()
    {
        _canGetDamage = false;
        Invoke(nameof(TakeOffImmortality), _immortalityTime);

    }

    private void TakeOffImmortality() => _canGetDamage = true;

    private void TakeDamage()
    {
        if (_canGetDamage == true)
            _hp--;
        if (_hp <= 0)
        {
            EventBus.Instance.OnGameOver.Invoke();
        }
    }
}
