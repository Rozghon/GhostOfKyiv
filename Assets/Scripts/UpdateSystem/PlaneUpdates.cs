using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Updates/PlaneUpdates")]
public class PlaneUpdates : ScriptableObject
{
    public string _name;

    public int _bestScore = 0;
    public int _flyPoint = 0;

    public int _healthLevel = 1;
    public int _damageLevel = 1;
    public int _speedLevel = 1;

    public int _healthPoints = 10;
    public int _damage = 2;
    public float _speed = 5;

    public int _healthPointsGrow = 2;
    public int _damageGrow = 1;
    public float _speedGrow = 0.2f;

    public int _healthUpPrice = 0;
    public int _damageUpPrice = 0;
    public int _speedUpPrice = 0;

    public void UpdatePrice()
    {
        _healthUpPrice = _healthLevel * _healthPoints * 100;
        _damageUpPrice = _damageLevel * _damage * 1000;
        _speedUpPrice = _speedLevel * (int)_speed * 1000;
    }
}
