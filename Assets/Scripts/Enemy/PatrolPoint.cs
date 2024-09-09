using UnityEngine;

public class PatrolPoint : MonoBehaviour
{
    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.GetComponent<PatrolMovement>())
        {
            collision.GetComponent<PatrolMovement>().ChangeDirection();
        }
    }

}
