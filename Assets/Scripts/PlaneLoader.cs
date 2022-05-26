using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PlaneLoader : MonoBehaviour
{
    [SerializeField] GameObject[] _planePrefabs;
    [SerializeField] Transform _spawnPoint;

    private void Awake()
    {
        int _selectedPlane = PlayerPrefs.GetInt("selectedPlane");
        Instantiate(_planePrefabs[_selectedPlane], _spawnPoint.position, Quaternion.identity);
    }
}
