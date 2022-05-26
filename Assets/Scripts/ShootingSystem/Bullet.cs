using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Bullet : MonoBehaviour
{
    public string _targetTag;
    public int _damage;

    [SerializeField] private GameObject _explosion;

    [SerializeField] private string _destroyTag;

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if(collision.tag == _destroyTag)
        {
            Destroy(this.gameObject);
        }
        if(collision.tag == _targetTag)
        {
            HealthController _healthController = collision.GetComponent<HealthController>();
            _healthController.GetDamage(_damage);

            Instantiate(_explosion, this.transform.position, Quaternion.identity);

            Destroy(this.gameObject);
        }
    }
}
