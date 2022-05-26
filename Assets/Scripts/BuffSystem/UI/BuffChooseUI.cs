using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class BuffChooseUI : MonoBehaviour
{
    [SerializeField] private BuffManager _buffManager;
    [SerializeField] private GameObject _cartsPanel;
    [SerializeField] private BuffCartUI[] _carts;

    public void ActivateCartsPanel()
    {
        Time.timeScale = 0f;
        _cartsPanel.SetActive(true);
        AddNewBuffCarts();
    }

    public void AddNewBuffCarts()
    {
       for(int i = 0; i < _carts.Length; i++)
       {
            _carts[i].AddNewCard(_buffManager.ChooseRandomBuff());
       }
    }

    public void ReturnBuff(int _cartNumber)
    {
        _buffManager.AddBuff(_carts[_cartNumber].ChooseBuff());
        _cartsPanel.SetActive(false);
        Time.timeScale = 1f;
    }
}