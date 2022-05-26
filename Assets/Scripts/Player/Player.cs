using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Player : MonoBehaviour
{
    private PlayerMovement _playerMovement;
    private HealthController _health;
    private Shooter _shooter;
    private SpriteRenderer _playerSprite;
    private Collider2D _playerCollider;

    private bool _isAlive;

    private void Awake()
    {
        _playerMovement = gameObject.GetComponent<PlayerMovement>();
        _health = gameObject.GetComponent<HealthController>();
        _shooter = gameObject.GetComponent<Shooter>();
        _playerSprite = transform.GetChild(0).GetComponent<SpriteRenderer>();
        _playerCollider = gameObject.GetComponent<Collider2D>();

        _health.FindPlayerHPBar();

        _isAlive = true;
    }

    private void Update()
    {
        if (_health.GetCurentHealth() <= 0)
        {
            DeactivatePlayer();
        }
    }

    public void ActivatePlayer()
    {
        _isAlive = true;

        _health.Heal(_health.GetMaxHealth());

        _playerSprite.enabled = true;
        _playerMovement.enabled = true;
        _shooter.enabled = true;
        _playerCollider.enabled = true;
    }

    public void DeactivatePlayer()
    {
        _isAlive = false;

        _playerSprite.enabled = false;
        _playerMovement.enabled = false;
        _shooter.enabled = false;
        _playerCollider.enabled = false;
    }

    public bool IsAlive()
    {
        return _isAlive;
    }
}