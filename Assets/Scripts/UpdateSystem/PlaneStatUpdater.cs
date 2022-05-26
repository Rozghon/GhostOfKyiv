using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneStatUpdater : MonoBehaviour
{
    [SerializeField] private PlaneUpdates _plane;

    private PlayerMovement _playerMovement;
    private Shooter _shooter;
    private HealthController _healthController;

    private void Start()
    {
        _playerMovement = gameObject.GetComponent<PlayerMovement>();
        _shooter = gameObject.GetComponent<Shooter>();
        _healthController = gameObject.GetComponent<HealthController>();

        _playerMovement.SetSpeed(_plane._speed);
        _shooter.SetNewDamage(_plane._damage);
        _healthController.SetHealth(_plane._healthPoints);
    }

    public PlaneUpdates GetPlane()
    {
        return _plane;
    }
}
