using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class EnemyDamageble : MonoBehaviour
{
    [SerializeField] private Animator _animator;
    [SerializeField] private UnityEvent _onDamage;
    private void Start()
    {
        _animator = GetComponentInChildren<Animator>();
        _onDamage.AddListener(()=>_animator.SetTrigger("Death"));
    }

    public void TakeDamage()
    {
        _onDamage.Invoke();
    }
    
    

}
