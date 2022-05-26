using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlaneHealthUpUI : MonoBehaviour
{
    [SerializeField] private PlaneUpdateUI _updateUI;

    [SerializeField] private TMP_Text _price;
    [SerializeField] private TMP_Text _level;

    private void Start()
    {
        _updateUI._plane.UpdatePrice();
        UpdateText();
    }

    public void UpdateHealth()
    {
        _updateUI.UpdateHealth();
        UpdateText();
    }

    private void UpdateText()
    {
        _price.text = _updateUI._plane._healthUpPrice.ToString();
        _level.text = "Level " + _updateUI._plane._healthLevel.ToString();
    }
}
