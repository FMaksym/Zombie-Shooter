using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class MenuUI : MonoBehaviour
{
    [Header("Buttons")]
    [SerializeField] private GameObject _playButton;
    [SerializeField] private GameObject _settingsButton;
    [SerializeField] private GameObject _rateUsButton;

    [Header("Panels")]
    [SerializeField] private GameObject _menuPanel;
    [SerializeField] private GameObject _selectGunPanel;
    [SerializeField] private GameObject _settingsPanel;
    [SerializeField] private GameObject _shopPanel;
    

    [Header("Canvases")]
    [SerializeField] private GameObject _menuCanvas;
    [SerializeField] private GameObject _settingsCanvas;
    [SerializeField] private GameObject _selectGunCanvas;

    [Header("MainCameras")]
    [SerializeField] private GameObject _menuCamera;
    [SerializeField] private GameObject _selectGunCamera;

    public void OnClickPlay()
    {
        _menuCanvas.SetActive(false);
        _menuCamera.SetActive(false);
        _selectGunCamera.SetActive(true);
        _selectGunCanvas.SetActive(true);
    }

    public void OnClickSettings()
    {
        _menuPanel.SetActive(false);
        OpenSettings();
    }

    public void OnClickShop()
    {
        _menuPanel.SetActive(false);
        _shopPanel.SetActive(true);
    }

    public void OnClickPlayBackToMenu()
    {
        _selectGunCanvas.SetActive(false);
        _selectGunCamera.SetActive(false);
        _menuCamera.SetActive(true);
        _menuCanvas.SetActive(true);
    }

    public void OnClickSettingsBackToMenu()
    {
        CloseSettings();
        _menuPanel.SetActive(true);
    }

    public void OnClickShopBackToMenu()
    {
        _shopPanel.SetActive(false);
        _menuPanel.SetActive(true);
    }

    private void OpenSettings()
    {
        _settingsCanvas.SetActive(true);
        _settingsPanel.transform.MoveAtSpeed(new Vector3(430,540,0), 1500f);
    }

    private void CloseSettings()
    {
        _settingsPanel.transform.MoveAtSpeed(new Vector3(-500, 540, 0), 2000f);
        _settingsCanvas.SetActive(false);
    }
}
