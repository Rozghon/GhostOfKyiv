using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class DecoySpawner : MonoBehaviour
{
    [SerializeField] private float _delay;

    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _firePoint;

    private bool _isCanShoot = true;

    private void Update()
    {
        if (_isCanShoot)
        {
            StartCoroutine(Shooting(_delay));
        }
    }

    private void Shoot()
    {
        GameObject _bullet = Instantiate(_bulletPrefab, _firePoint.position, _firePoint.rotation);
    }

    private IEnumerator Shooting(float _delayTime)
    {
        _isCanShoot = false;
        Shoot();
        yield return new WaitForSeconds(_delayTime);
        _isCanShoot = true;
    }
}