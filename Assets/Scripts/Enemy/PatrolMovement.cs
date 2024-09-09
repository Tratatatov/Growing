using UnityEngine;
using UnityEngine.PlayerLoop;
public class PatrolMovement : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField]private float _direction = 1f;
    [SerializeField] private Transform _pointA;
    [SerializeField] private Transform _pointB;
    [SerializeField] private Transform _currentPoint;
  
  
    private void Update()
    {
        Move(_currentPoint);
        ChangeDirection();

        RightRotation();
    }
    public void ChangeDirection()
    {
        if (Vector2.Distance(transform.position, _currentPoint.position) <= .2f)
        {
            if (_currentPoint == _pointA)
            {
                _currentPoint = _pointB;
                _direction = 1;
            }
            else
            {
                _currentPoint = _pointA;
                _direction = -1;
            }
        }

    }
    private void RightRotation()
    {
        switch (_direction)
        {
            case 1:
                transform.rotation = Quaternion.Euler(0, 180, 0);
                break;
            case -1:
                transform.rotation = Quaternion.Euler(0, 0, 0);
                break;
        }
    }

    private void Move(Transform destination)
    {
        transform.position = Vector2.MoveTowards(transform.position, destination.position, _speed * Time.deltaTime);
    }
    
   
}
