using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class MapSelection : MonoBehaviour
{
    [SerializeField] private GameObject[] _maps;
    [SerializeField] private int _selectedMap = 0;

    public void NextMap()
    {
        _maps[_selectedMap].SetActive(false);
        _selectedMap = (_selectedMap + 1) % _maps.Length;
        _maps[_selectedMap].SetActive(true);
    }

    public void PreviousMap()
    {
        _maps[_selectedMap].SetActive(false);
        _selectedMap--;
        if (_selectedMap < 0)
        {
            _selectedMap += _maps.Length;
        }
        _maps[_selectedMap].SetActive(true);
    }

    public void StartGame()
    {
        SceneManager.LoadScene(_selectedMap + 1, LoadSceneMode.Single);
    }
}