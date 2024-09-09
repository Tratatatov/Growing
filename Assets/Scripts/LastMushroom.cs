using System.Collections;
using System.Collections.Generic;
using Unity.VisualScripting;
using UnityEngine;

public class LastMushroom : MonoBehaviour
{
    void Start()
    {
        EventBus.Instance.OnPlayerDamage.AddListener(GrowAgain); 
    }

    private void GrowAgain()
    {
        gameObject.SetActive(true);
    }
}
