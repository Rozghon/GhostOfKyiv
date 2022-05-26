using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneUpdateUI : MonoBehaviour
{
    public PlaneUpdates _plane;

    public void UpdateHealth()
    {
        _plane.UpdatePrice();
        if(_plane._flyPoint >= _plane._healthUpPrice)
        {
            _plane._flyPoint -= _plane._healthUpPrice;
            _plane._healthLevel++;
            _plane._healthPoints += _plane._healthPointsGrow;

            GameSaveManager.instance.SaveGame();
        }
    }

    public void UpdateDamage()
    {
        _plane.UpdatePrice();
        if(_plane._flyPoint >= _plane._damageUpPrice)
        {
            _plane._flyPoint -= _plane._damageUpPrice;
            _plane._damageLevel++;
            _plane._damage += _plane._damageGrow;

            GameSaveManager.instance.SaveGame();
        }
    }

    public void UpdateSpeed()
    {
        _plane.UpdatePrice();
        if(_plane._flyPoint >= _plane._speedUpPrice)
        {
            _plane._flyPoint -= _plane._speedUpPrice;
            _plane._speedLevel++;
            _plane._speed += _plane._speedGrow;

            GameSaveManager.instance.SaveGame();
        }
    }
}
