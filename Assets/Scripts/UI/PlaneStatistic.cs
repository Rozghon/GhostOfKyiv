using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TMPro;

public class PlaneStatistic : MonoBehaviour
{
    [SerializeField] private PlaneUpdates _plane;

    [SerializeField] private TMP_Text _bestScoreText;
    [SerializeField] private TMP_Text _flyPointsText;

    private void Update()
    {
        _bestScoreText.text = _plane._bestScore.ToString();
        _flyPointsText.text = _plane._flyPoint.ToString();
    }
}
