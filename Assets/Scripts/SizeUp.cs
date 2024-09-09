using UnityEngine;
using UnityEngine.Events;

public class SizeUp : MonoBehaviour
{
    [SerializeField] private ParticleSystem _effect;
    [SerializeField] private AudioSource _sound;
    [SerializeField] private UnityEvent _onDestroyEffect;
    [SerializeField] private Transform _spawnPosition;

    public void CreateEffect()
    {
        Instantiate(_effect, _spawnPosition.position, Quaternion.identity);
        AudioSource sound = Instantiate(_sound, transform.position, Quaternion.identity);
        sound.pitch = Random.Range(0.8f, 1f);
    }

    private void Start()
    {
        _onDestroyEffect.AddListener(() => gameObject.SetActive(false));
        EventBus.Instance.OnGameOver.AddListener(() => gameObject.SetActive(true));
    }
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponentInParent<PlayerMovement>())
        {
            EventBus.Instance.OnIncreaseSize.Invoke();
            _onDestroyEffect.Invoke();
        }
    }
   
}
