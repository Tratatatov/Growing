using System;
using UnityEngine;

public class Breakable : MonoBehaviour
{
    private Action _onBreak;
    [SerializeField] private GameObject _effect;

    private void OnEnable()
    {
        _onBreak += () => Instantiate(_effect, transform.position, Quaternion.identity);
        _onBreak += () => gameObject.SetActive(false);
    }

    private void OnDisable()
    {

        _onBreak -= () => Instantiate(_effect, transform.position, Quaternion.identity);
        _onBreak -= () => gameObject.SetActive(false);
    }


    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.collider.GetComponent<Breaker>() != null)
        {
            _onBreak?.Invoke();
        }
    }



}
