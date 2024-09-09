using UnityEngine;

public class LostControl : MonoBehaviour
{
    [SerializeField] private float _time;
    private PlayerMovement _movement;
    private void Start()
    {
        _movement = GetComponent<PlayerMovement>();
        EventBus.Instance.OnPlayerDamage.AddListener(TurnOffControl);
    }
    private void TurnOffControl()
    {
        _movement.enabled = false;
        Invoke(nameof(TurnOnControl), _time);
    }
    private void TurnOnControl()
    {
        _movement.enabled = true;
    }
}
