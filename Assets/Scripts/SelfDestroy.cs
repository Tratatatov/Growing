using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SelfDestroy : MonoBehaviour
{
    [SerializeField] private float _time; 
    void Start()
    {
        Destroy(gameObject, _time);
    }
}
