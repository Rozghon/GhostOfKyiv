using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[CreateAssetMenu(menuName = "Updates/SityUpdates")]
public class SityUpdates : ScriptableObject
{
    public string _name;
    public string _description;

    public int _bestScore = 0;
    public int _sityPoint = 0;

    public int _healthLevel = 1;
    public int _regenLevel = 1;
    public int _antiAirLevel = 1;

    public int _healthPoints = 100;
    public int _healthRegen = 1;
    public int _antiAirDamage = 1;

    public int _healthPointsGrow = 10;
    public int _healthRegenGrow = 1;
    public int _antiAirDamageGrow = 1;

    public int _healthUpPrice = 0;
    public int _regenUpPrice = 0;
    public int _antiAirDamageUpPrice = 0;

    public void UpdatePrice()
    {
        _healthUpPrice = _healthLevel * _healthPoints * 10;
        _regenUpPrice = _regenLevel * _healthRegen * 1000;
        _antiAirDamageUpPrice = _antiAirLevel * _antiAirDamage * 1000;
    }
}
