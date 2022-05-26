using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class ScoreViewer : MonoBehaviour
{
    private TMP_Text _scoreText;

    private int _currentScore = 0;

    private void Start()
    {
        _scoreText = gameObject.GetComponent<TMP_Text>();
        _currentScore = 0;
    }

    private void Update()
    {
        _scoreText.text = _currentScore.ToString();
    }

    public void AddScore(int _value)
    {
        _currentScore += _value;
    }

    public int GetScore()
    {
        return _currentScore;
    }
}
