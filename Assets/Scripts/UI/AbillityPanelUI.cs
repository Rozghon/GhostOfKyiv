using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class AbillityPanelUI : MonoBehaviour
{
    [SerializeField] private GameObject _currentPanel;
    [SerializeField] private GameObject _abillityPanel;

    [SerializeField] private Image _icon;
    [SerializeField] private TMP_Text _name;
    [SerializeField] private TMP_Text _description;

    public void ActivateAbillity(Buff _abillity)
    {
        _abillityPanel.SetActive(true);
        _icon.sprite = _abillity._icon;
        _name.text = _abillity._name;
        _description.text = _abillity._description;
        _currentPanel.SetActive(false);
    }
}
