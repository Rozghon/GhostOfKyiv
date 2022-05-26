using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class SityStatistic : MonoBehaviour
{
    [SerializeField] private SityUpdates _sity;

    [SerializeField] private TMP_Text _bestScoreText;
    [SerializeField] private TMP_Text _sityPointsText;

    private void Update()
    {
        _bestScoreText.text = _sity._bestScore.ToString();
        _sityPointsText.text = _sity._sityPoint.ToString();
    }
}
