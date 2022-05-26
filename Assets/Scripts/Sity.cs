using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class Sity : MonoBehaviour
{
    [SerializeField] private float _playerRespawnTime;
    [SerializeField] private Transform _playerSpawnPosition;
    [SerializeField] private GameObject _gameOverUI;

    private SpriteRenderer _sitySprite;
    private GameObject _player;
    private Player _playerScript;

    private HealthController _health;

    private void Awake()
    {
        GameRuller.instance.RestartScene();
    }

    private void Start()
    {
        _player = GameObject.FindGameObjectWithTag("Player");
        _playerScript = _player.GetComponent<Player>();
        _health = gameObject.GetComponent<HealthController>();
        _sitySprite = transform.GetChild(0).GetComponent<SpriteRenderer>();
        _gameOverUI.SetActive(false);
        Time.timeScale = 1f;

        _health.FindSityHPBar();
    }

    private void Update()
    {
        if (_health.GetCurentHealth() <= 0)
        {
            _gameOverUI.SetActive(true);
            _sitySprite.enabled = false;

            GameSaveManager.instance.SaveGame();

            Time.timeScale = 0f;
        }

        if(!_playerScript.IsAlive())
        {
            _player.transform.position = _playerSpawnPosition.position;
            StartCoroutine(PlayerRespawn());
        }
    }

    private IEnumerator PlayerRespawn()
    {
        yield return new WaitForSeconds(_playerRespawnTime);
        _playerScript.ActivatePlayer();
    }
}