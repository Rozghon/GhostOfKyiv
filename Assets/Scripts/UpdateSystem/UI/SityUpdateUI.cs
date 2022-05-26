using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class SityUpdateUI : MonoBehaviour
{
    public SityUpdates _sity;

    public void UpdateHealth()
    {
        _sity.UpdatePrice();
        if(_sity._sityPoint >= _sity._healthUpPrice)
        {
            _sity._sityPoint -= _sity._healthUpPrice;
            _sity._healthLevel++;
            _sity._healthPoints += _sity._healthPointsGrow;

            GameSaveManager.instance.SaveGame();
        }
    }

    public void UpdateRegen()
    {
        _sity.UpdatePrice();
        if(_sity._sityPoint >= _sity._regenUpPrice)
        {
            _sity._sityPoint -= _sity._regenUpPrice;
            _sity._regenLevel++;
            _sity._healthRegen += _sity._healthRegenGrow;

            GameSaveManager.instance.SaveGame();
        }
    }

    public void UpdateAntiAirDamage()
    {
        _sity.UpdatePrice();
        if(_sity._sityPoint >= _sity._antiAirDamageUpPrice)
        {
            _sity._sityPoint -= _sity._antiAirDamageUpPrice;
            _sity._antiAirLevel++;
            _sity._antiAirDamage += _sity._antiAirDamageGrow;

            GameSaveManager.instance.SaveGame();
        }
    }
}
