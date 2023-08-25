using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class HealthBar : MonoBehaviour
{
    [SerializeField] Player _player;
    [SerializeField] RatHead _ratHead;

    private List<RatHead> _heads = new List<RatHead>();

    private void OnEnable()
    {
        _player.Healthchanged += OnHealthChanged;
    }

    private void OnDisable()
    {
        _player.Healthchanged -= OnHealthChanged;
    }

    private void OnHealthChanged(int value)
    {
        if (_heads.Count < value)
        {
            int createHead = value - _heads.Count;

            for (int i = 0; i < createHead; i++)
            {
                CreateHead();
            }
        }
        else if (_heads.Count > value)
        {
            int destroyHead =_heads.Count - value;

            for (int i = 0; i < destroyHead; i++)
            {
                DestroyHead(_heads[_heads.Count - 1]);
            }
        }
    }

    private void DestroyHead(RatHead ratHead)
    {
        _heads.Remove(ratHead);
        ratHead.ToLost();
    }

    private void CreateHead()
    {
        RatHead head = Instantiate(_ratHead, transform);
        _heads.Add(head.GetComponent<RatHead>());
        head.ToEmpty();
    }
}
