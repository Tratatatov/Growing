using UnityEngine;

public class RandomFlip : MonoBehaviour
{
    private SpriteRenderer _spriteRenderer;
    private void Awake()
    {
        _spriteRenderer = GetComponent<SpriteRenderer>();
        int randomX = Random.Range(0, 2);

        if (randomX == 0)
        {
            _spriteRenderer.flipX = true;
        }

        else
        {
            _spriteRenderer.flipX = false;
        }
        int randomY = Random.Range(0, 2);
        
        if (randomX == 0)
        {
            _spriteRenderer.flipY = true;
        }
        else
        {
            _spriteRenderer.flipY = false;
        }

    }
}
