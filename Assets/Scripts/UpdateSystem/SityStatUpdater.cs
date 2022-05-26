using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SityStatUpdater : MonoBehaviour
{
    [SerializeField] SityUpdates _sity;

    private HealthController _healthController;
    private AntiAir[] _antiAirs;

    private void Start()
    {
        _healthController = gameObject.GetComponent<HealthController>();
        _antiAirs = GameObject.FindObjectsOfType<AntiAir>();

        _healthController.SetHealth(_sity._healthPoints);
        _healthController.SetRegen(_sity._healthRegen);

        for (int i = 0; i < _antiAirs.Length; i++)
        {
            _antiAirs[i].SetDamage(_sity._antiAirDamage);
        }
    }

    public SityUpdates GetSity()
    {
        return _sity;
    }
}
