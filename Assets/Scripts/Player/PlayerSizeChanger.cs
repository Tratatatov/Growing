using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class PlayerSizeChanger : MonoBehaviour
{
    [SerializeField] private GameObject _smallPlayer;
    [SerializeField] private GameObject _mediumPlayer;
    [SerializeField] private GameObject _bigPlayer;
    [SerializeField] private int _sizeIndex = 0;
    public int SizeIndex => _sizeIndex;
    private void Start()
    {
        EventBus.Instance.OnIncreaseSize.AddListener(Grow);
        EventBus.Instance.OnPlayerDamage.AddListener(BecomeSmaller);
    }
    private void Update()
    {
        ChangeSize();
    }
    private void BecomeSmaller()
    {
        if (_sizeIndex > 0)
        {
            _sizeIndex--;
        }
    }
    private void Grow()
    {
        if (_sizeIndex < 2)
        {
            _sizeIndex++;
        }
    }
    private void ChangeSize()
    {
        switch (_sizeIndex)
        {
            case 0:
                _smallPlayer.SetActive(true);
                _mediumPlayer.SetActive(false);
                _bigPlayer.SetActive(false);
                break;
            case 1:
                _smallPlayer.SetActive(false);
                _mediumPlayer.SetActive(true);
                _bigPlayer.SetActive(false);
                break;
            case 2:
                _smallPlayer.SetActive(false);
                _mediumPlayer.SetActive(false);
                _bigPlayer.SetActive(true);
                break;
        }
    } 

}
