using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Shooter : MonoBehaviour
{
    [SerializeField] private string _targetTag;

    [SerializeField] private float _attackDistance;
    [SerializeField] private float _delay;
    [SerializeField] private float _bulletSpeed;

    [SerializeField] private int _bulletDamage;

    [SerializeField] private LayerMask _objectSelectionMask;
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private Transform _firePoint;

    private int _startingBulletDamage;
    private bool _isCanShoot = true;

    private void Update()
    {
        if(_isCanShoot && Physics2D.Raycast(_firePoint.position, _firePoint.up, _attackDistance, _objectSelectionMask))
        {
            StartCoroutine(Shooting(_delay));
        }
    }

    private void Shoot()
    {
        GameObject _bullet = Instantiate(_bulletPrefab, _firePoint.position, _firePoint.rotation);

        Rigidbody2D _rb = _bullet.GetComponent<Rigidbody2D>();
        _rb.AddForce(_firePoint.up * _bulletSpeed, ForceMode2D.Impulse);

        Bullet _bulletScript = _bullet.GetComponent<Bullet>();
        _bulletScript._targetTag = _targetTag;
        _bulletScript._damage = _bulletDamage;
    }

    private IEnumerator Shooting(float _delayTime)
    {
        _isCanShoot = false;
        Shoot();
        yield return new WaitForSeconds(_delayTime);
        _isCanShoot = true;
    }

    public void UpDamage(int _value)
    {
        _bulletDamage += _value;
    }

    public void UpAttackSpeed(float _value)
    {
        _delay -= _value;
    }

    public void SetStartingStats()
    {
        _startingBulletDamage = _bulletDamage;
    }

    public void SetDamage()
    {
        int _level = GameRuller.instance.GetLevel();
        _bulletDamage = _startingBulletDamage + (int)((float)_level * 0.3f);
    }

    public void SetTargetTag(string _value)
    {
        _targetTag = _value;
    }

    public void SetNewDamage(int _value)
    {
        _bulletDamage = _value;
        SetStartingStats();
    }
}