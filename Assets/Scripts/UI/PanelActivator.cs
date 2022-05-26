using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class PanelActivator : MonoBehaviour
{
    [SerializeField] private GameObject _currentPanel;
    [SerializeField] private GameObject _nextPanel;

    public void ActivateNextPanel()
    {
        _nextPanel.SetActive(true);
        _currentPanel.SetActive(false);
    }
}
