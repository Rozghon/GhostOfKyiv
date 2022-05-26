using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class PausePanel : MonoBehaviour
{
    [SerializeField] private GameObject _pausePanel;

    private void Awake()
    {
        Resume();
    }

    public void Resume()
    {
        _pausePanel.SetActive(false);
        Time.timeScale = 1f;
    }

    public void Pause()
    {
        _pausePanel.SetActive(true);
        Time.timeScale = 0f;
    }

    public void Restart()
    {
        SceneManager.LoadScene(SceneManager.GetActiveScene().buildIndex);
    }

    public void Exit()
    {
        SceneManager.LoadScene(0);
    }
}
