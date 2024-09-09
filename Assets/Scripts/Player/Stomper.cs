using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Stomper : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<EnemyDamageble>())
        {
            collision.GetComponent<EnemyDamageble>().TakeDamage();
            EventBus.Instance.OnKnockUp.Invoke();
        }
    }
}
