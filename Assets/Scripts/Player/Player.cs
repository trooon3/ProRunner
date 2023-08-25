using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Player : MonoBehaviour
{
    [SerializeField] int _health;
    [SerializeField] int _maxHealth;

    public event UnityAction<int> Healthchanged;
    public event UnityAction Died;

    public void ApplyDamage(int damage)
    {
        _health -= damage;
        Healthchanged?.Invoke(_health);

        if (_health <= 0)
        {
            Die();
        }
    }

    public void ApplyHeal(int heal)
    {
        _health += heal;

        if (_health >= _maxHealth)
        {
            _health = _maxHealth;
        }
        Healthchanged?.Invoke(_health);
    }

    public void Die()
    {
        Died?.Invoke();
    }
}
