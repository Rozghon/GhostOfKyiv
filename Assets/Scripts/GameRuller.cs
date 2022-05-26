using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class GameRuller : MonoBehaviour
{
    [SerializeField] private int _requiredKills;
    [SerializeField] private int _grow;

    private int _level = 1;
    private int _startingRequiredKills;
    private int _curentKills;

    [SerializeField] private BuffChooseUI _buffUI;
    [SerializeField] private PlaneUpdates _plane;
    [SerializeField] private SityUpdates _sity;
    [SerializeField] private ScoreViewer _scoreViewer;

    public static GameRuller instance;

    private void Awake()
    {
        if (instance != null)
        {
            Destroy(gameObject);
        }
        else
        {
            instance = this;
            DontDestroyOnLoad(gameObject);
        }

        _startingRequiredKills = _requiredKills;
    }

    private void Update()
    {
        if(_curentKills >= _requiredKills)
        {
            _buffUI = GameObject.FindObjectOfType<BuffChooseUI>();
            _buffUI.ActivateCartsPanel();
            _requiredKills += _grow;
            _curentKills = 0;
            _level++;
        }
    }

    public void KillEnemy(int _score)
    {
        _curentKills++;

        _plane = GameObject.FindObjectOfType<PlaneStatUpdater>().GetPlane();
        _sity = GameObject.FindObjectOfType<SityStatUpdater>().GetSity();
        _scoreViewer = GameObject.FindObjectOfType<ScoreViewer>();
        _scoreViewer.AddScore(_score);
        _plane._flyPoint += _score * _level;
        _sity._sityPoint += (_score * _level) / 10;

        if(_scoreViewer.GetScore() > _plane._bestScore)
        {
            _plane._bestScore = _scoreViewer.GetScore();
        }
        if(_scoreViewer.GetScore() > _sity._bestScore)
        {
            _sity._bestScore = _scoreViewer.GetScore();
        }
    }

    public int GetLevel()
    {
        return _level;
    }

    public void RestartScene()
    {
        _level = 1;
        _curentKills = 0;
        _requiredKills = _startingRequiredKills;

        _buffUI = GameObject.FindObjectOfType<BuffChooseUI>();
        _plane = GameObject.FindObjectOfType<PlaneStatUpdater>().GetPlane();
        _sity = GameObject.FindObjectOfType<SityStatUpdater>().GetSity();
        _scoreViewer = GameObject.FindObjectOfType<ScoreViewer>();
    }

    public float GetFillAmount()
    {
        return (float)_curentKills / (float)_requiredKills;
    }
}