using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SityAntiAirUpUI : MonoBehaviour
{
    [SerializeField] private SityUpdateUI _updateUI;

    [SerializeField] private TMP_Text _price;
    [SerializeField] private TMP_Text _level;

    private void Start()
    {
        _updateUI._sity.UpdatePrice();
        UpdateText();
    }

    public void UpdateAntiAir()
    {
        _updateUI.UpdateAntiAirDamage();
        UpdateText();
    }

    private void UpdateText()
    {
        _price.text = _updateUI._sity._antiAirDamageUpPrice.ToString();
        _level.text = "Level " + _updateUI._sity._antiAirLevel.ToString();
    }
}
