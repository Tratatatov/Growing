using UnityEngine;
using UnityEngine.Events;

public class EventBus : MonoBehaviour
{
    public static EventBus Instance;
    public UnityEvent OnIncreaseSize;
    public UnityEvent OnKnockUp;
    public UnityEvent OnPlayerDamage;
    public UnityEvent OnGameOver;
    public UnityEvent OnFinished;
    private void Awake()
    {
        if (Instance != null)
        {
            Destroy(gameObject);
        }
        Instance = this;
    }

   
}
