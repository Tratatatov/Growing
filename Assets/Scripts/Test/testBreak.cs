using Unity.VisualScripting;
using UnityEngine;
using UnityEngine.Tilemaps;

public class testBreak : MonoBehaviour
{
    private Tilemap _tilemap;
    private Collision2D _collision;
    private void Start()
    {
        _tilemap = GetComponent<Tilemap>();
    }
    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.GetComponent<Breaker>())
        {
            //Debug.Log("Шалость удалась");
            _collision = collision;
            foreach (ContactPoint2D contact in collision.contacts)
            {
                Vector3Int point= _tilemap.WorldToCell(contact.point);
                _tilemap.SetTile(point, null);
            }
        }
    }
  
}
