using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class LevelViewer : MonoBehaviour
{
    [SerializeField] private Image _fillImage;
    [SerializeField] private TMP_Text _levelText;

    [SerializeField] private GameRuller _gameRuller;

    private void Start()
    {
        _gameRuller = GameObject.FindObjectOfType<GameRuller>();
        _fillImage.fillAmount = _gameRuller.GetFillAmount();
        _levelText.text = _gameRuller.GetLevel().ToString();
    }

    private void Update()
    {
        if(_gameRuller == null)
        {
            _gameRuller = GameObject.FindObjectOfType<GameRuller>();
        }

        _fillImage.fillAmount = _gameRuller.GetFillAmount();
        _levelText.text = _gameRuller.GetLevel().ToString();
    }


}
