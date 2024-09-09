using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Tilemaps;

public class CollisionTest : MonoBehaviour
{
    [SerializeField] private Tilemap _tilemap;
    [SerializeField] private bool _isTrigger;
    [SerializeField] private bool _isStaying;
    [SerializeField] private List<Collider2D> colliders;

    private void Start()
    {
       // _tilemap = FindObjectOfType<Breakable>().GetComponent<Tilemap>();
    }
    private void Overlap()
    {

    }
    //private void OnCollisionEnter2D(Collision2D collision)
    //{
    //    if (_isTrigger) return;
    //    if (collision.gameObject.GetComponent<Breakable>())
    //    {
    //        foreach(ContactPoint2D point in collision.contacts)
    //        {
    //        DestroyTile(point.point);

    //        }
    //    }
    //}
    private void OnCollisionStay2D(Collision2D collision)
    {
        Debug.Log("Stay");
        if (collision.gameObject.GetComponent<Breakable>())
        {
            foreach (ContactPoint2D point in collision.contacts)
            {
                DestroyTile(point.point);
            }
        }
    }
    private void DestroyTile(Vector2 position)
    {
        Vector3Int tilePosition = _tilemap.WorldToCell(position);
        _tilemap.SetTile(tilePosition, null);
    }
}
