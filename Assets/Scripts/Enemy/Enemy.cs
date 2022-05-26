using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Enemy : MonoBehaviour
{
    [SerializeField] private string _targetTag;
    [SerializeField] private int _reward = 100;
    [SerializeField] private GameObject _explosion;

    private EnemyMovement _enemyMovement;
    private HealthController _health;
    private Shooter _shooter;
    private Missle _missle;

    private void Awake()
    {
        _enemyMovement = gameObject.GetComponent<EnemyMovement>();
        _enemyMovement._targetTag = _targetTag;
        _enemyMovement.SetStartingStats();
        _enemyMovement.SetSpeed();
        _enemyMovement.SetTurnSpeed();

        _health = gameObject.GetComponent<HealthController>();
        _health.SetStartingStats();
        _health.SetMaxHealth();

        if(gameObject.GetComponent<Shooter>() != null)
        {
            _shooter = gameObject.GetComponent<Shooter>();
            _shooter.SetStartingStats();
            _shooter.SetDamage();
        }

        if(gameObject.GetComponent<Missle>() != null)
        {
            _missle = gameObject.GetComponent<Missle>();
            _missle.SetStartingStats();
            _missle.SetDamage();
        }
    }

    private void Update()
    {
        if (_health.GetCurentHealth() <= 0)
        {
            GameRuller.instance.KillEnemy(_reward);
            Instantiate(_explosion, this.transform.position, Quaternion.identity);
            Destroy(gameObject);
        }
    }
}