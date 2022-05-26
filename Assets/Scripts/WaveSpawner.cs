using System.Collections;
using System.Collections.Generic;
using UnityEngine;

[System.Serializable]
public class Wave
{
    public string _waveName;
    public int _numberOfEnemies;
    public GameObject[] _typeOfEnemies;
    public float _spawnInterval;
}

public class WaveSpawner : MonoBehaviour
{
    [SerializeField] private Wave[] _waves;
    [SerializeField] private Transform[] _spawnPoints;
    [SerializeField] private float _nextSpawnTime = 1f;
    private bool _isSpawning = false;

    private void Update()
    {
        if (!_isSpawning)
        {
            StartCoroutine(SpawnWave(Random.Range(0, _waves.Length)));
        }
    }

    private IEnumerator SpawnWave(int _waveNumber)
    {
        _isSpawning = true;
        Wave _currentWave = _waves[_waveNumber];

        for(int i = 0; i < _currentWave._numberOfEnemies; i++)
        {
            SpawnEnemy(ChoseEnemy(_currentWave), ChoseSpawnPoint());
            yield return new WaitForSeconds(_currentWave._spawnInterval);
        }

        yield return new WaitForSeconds(_nextSpawnTime);
        _isSpawning = false;
    }

    private void SpawnEnemy(GameObject _enemy, Transform _spawnPosition)
    {
        Vector3 _spawnPositionVector = new Vector3(_spawnPosition.position.x, _spawnPosition.position.y, 0);
        Instantiate(_enemy, _spawnPositionVector, Quaternion.identity);
    }

    private Transform ChoseSpawnPoint()
    {
        return _spawnPoints[Random.Range(0, _spawnPoints.Length)];
    }

    private GameObject ChoseEnemy(Wave _wave)
    {
        return _wave._typeOfEnemies[Random.Range(0, _wave._typeOfEnemies.Length)];
    }
}