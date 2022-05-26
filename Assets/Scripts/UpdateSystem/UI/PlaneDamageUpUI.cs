using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlaneDamageUpUI : MonoBehaviour
{
    [SerializeField] private PlaneUpdateUI _updateUI;

    [SerializeField] private TMP_Text _price;
    [SerializeField] private TMP_Text _level;

    private void Start()
    {
        _updateUI._plane.UpdatePrice();
        UpdateText();
    }

    public void UpdateDamage()
    {
        _updateUI.UpdateDamage();
        UpdateText();
    }

    private void UpdateText()
    {
        _price.text = _updateUI._plane._damageUpPrice.ToString();
        _level.text = "Level " + _updateUI._plane._damageLevel.ToString();
    }
}
