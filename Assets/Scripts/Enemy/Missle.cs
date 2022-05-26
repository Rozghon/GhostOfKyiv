using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Missle : MonoBehaviour
{
    [SerializeField] private string _targetTag;
    [SerializeField] private int _damage;
    [SerializeField] private GameObject _explosion;

    private int _startingDamage;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.tag == _targetTag)
        {
            HealthController _healthController = collision.GetComponent<HealthController>();
            _healthController.GetDamage(_damage);
            Instantiate(_explosion, this.transform.position, Quaternion.identity);

            Destroy(this.gameObject);
        }
    }

    public void SetStartingStats()
    {
        _startingDamage = _damage;
    }

    public void SetDamage()
    {
        int _level = GameRuller.instance.GetLevel();
        _damage = _startingDamage + (int)((float)_level * 0.3f);
    }

    public void SetTargetTag(string _value)
    {
        _targetTag = _value;
    }
}