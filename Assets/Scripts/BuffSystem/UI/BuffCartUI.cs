using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class BuffCartUI : MonoBehaviour
{
    public Image _icon;
    public TMP_Text _title;
    public TMP_Text _description;

    private Buff _curentBuff;

    public void AddNewCard(Buff _buff)
    {
        _icon.sprite = _buff._icon;
        _title.text = _buff._name;
        _description.text = _buff._description;
        _curentBuff = _buff;
    }

    public Buff ChooseBuff()
    {
        return _curentBuff;
    }
}
