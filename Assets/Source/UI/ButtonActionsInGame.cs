using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;

public class ButtonActionsInGame : MonoBehaviour
{
    [SerializeField] private GameObject _playerInputPanel;
    [SerializeField] private GameObject _playerInterfacePanel;
    [SerializeField] private GameObject _pausePanel;

    private bool _isPause = false;

    public void Pause()
    {
        if (!_isPause)
        {
            _isPause = true;
            Time.timeScale = 0;
            _playerInterfacePanel.SetActive(false);
            _playerInputPanel.SetActive(false);
            _pausePanel.SetActive(true);
        }
    }

    public void Resume()
    {
        if (_isPause)
        {
            _isPause = false;
            _playerInterfacePanel.SetActive(true);
            _playerInputPanel.SetActive(true);
            _pausePanel.SetActive(false);
            Time.timeScale = 1;
        }
    }

    public void Restart()
    {
        _isPause = false;
        Time.timeScale = 1;
        SceneManager.LoadScene(1);
    }

    public void InMenu()
    {
        Time.timeScale = 1;
        SceneManager.LoadScene(0);
    }

    //private void Update()
    //{
    //    if (!_isPause)
    //    {
    //        if (Input.GetKeyDown(KeyCode.Escape))
    //        {
    //            Pause();
    //            Cursor.visible = true;
    //        }
    //    }
    //    else
    //    {
    //        if (Input.GetKeyDown(KeyCode.Escape))
    //        {
    //            Resume();
    //            Cursor.visible = false;
    //            Cursor.lockState = CursorLockMode.Locked;
    //        }
    //    }
    //}
}
