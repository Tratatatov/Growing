using UnityEngine;

public class EnemyDeathEvent : MonoBehaviour
{
    [SerializeField] private ParticleSystem _effect;

    public void InvokeEffect()
    {
        Instantiate(_effect, transform.position, Quaternion.identity);
        gameObject.SetActive(false);
    }
}
