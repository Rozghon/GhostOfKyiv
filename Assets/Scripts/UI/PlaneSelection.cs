using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneSelection : MonoBehaviour
{
    [SerializeField] private GameObject[] _planes;
    [SerializeField] private int _selectedPlane = 0;

    public void NextPlane()
    {
        _planes[_selectedPlane].SetActive(false);
        _selectedPlane = (_selectedPlane + 1) % _planes.Length;
        _planes[_selectedPlane].SetActive(true);
    }

    public void PreviousPlane()
    {
        _planes[_selectedPlane].SetActive(false);
        _selectedPlane--;
        if(_selectedPlane < 0)
        {
            _selectedPlane += _planes.Length;
        }
        _planes[_selectedPlane].SetActive(true);
    }

    public void StartGame()
    {
        PlayerPrefs.SetInt("selectedPlane", _selectedPlane);
    }
}