using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shocker : MonoBehaviour
{
    [SerializeField] private int _damage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        HealthController _health = collision.GetComponent<HealthController>();

        _health.GetDamage(_damage);
    }
}
