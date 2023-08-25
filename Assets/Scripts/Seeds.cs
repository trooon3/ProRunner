using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Seeds : MonoBehaviour
{
    [SerializeField] private int _heal;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.TryGetComponent(out Player player))
        {
            player.ApplyHeal(_heal);
            Die();
        }
        else if (collision.TryGetComponent(out Destroyer destroyer))
        {
            Die();
        }
    }

    private void Die()
    {
        gameObject.SetActive(false);
    }
}
