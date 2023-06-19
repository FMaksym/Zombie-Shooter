using System;
using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.SceneManagement;
using TMPro;
using PlayerPrefs = PlayerPrefsWrapper;

public class SelectGunUI : MonoBehaviour
{
    [Header("Selected Gun")]
    [SerializeField] private GameObject _selectedGun;

    [Header("Sounds")]
    [SerializeField] private AudioClip _notEnoughtCoinSound;
    [SerializeField] private AudioClip _buyGunSound;
    [SerializeField] private AudioClip _equipGunSound;
    [SerializeField] private AudioClip _buttonSound;

    [Header("Amount Money Text")]
    [SerializeField] TMP_Text _moneyAmountText;

    [Header("Price Text")]
    [SerializeField] TMP_Text _priceText;

    [Header("Lists with Guns")]
    [SerializeField] private List<WeaponData> _pistols = new();
    [SerializeField] private List<WeaponData> _submachines = new();
    [SerializeField] private List<WeaponData> _shotguns = new();
    [SerializeField] private List<WeaponData> _rifles = new();
    [SerializeField] private List<WeaponData> _snipers = new();

    [Header("Buttons For type of Gun")]
    [SerializeField] private GameObject _pistolsButton;
    [SerializeField] private GameObject _submachinesButton;
    [SerializeField] private GameObject _shotgunsButton;
    [SerializeField] private GameObject _riflesButton;
    [SerializeField] private GameObject _snipersButton;

    [Header("Buttons For Select Gun")]
    [SerializeField] private GameObject _nextVeaponButton;
    [SerializeField] private GameObject _lastVeaponButton;
    [SerializeField] private GameObject _buyGunButton;
    [SerializeField] private GameObject _selectGunButton;
    [SerializeField] private GameObject _equipedGunButton;

    [Header("Panels")]
    [SerializeField] private GameObject _selectTypeOfGunPanel;
    [SerializeField] private GameObject _selectGunPanel;

    [Header("Guns Parametres Text")]
    [SerializeField] private TMP_Text _NameOfGun;
    [SerializeField] private TMP_Text _damageOfGun;
    [SerializeField] private TMP_Text _shootRangeOfGun;
    [SerializeField] private TMP_Text _reloadingOfGun;

    [Header("Canvases")]
    [SerializeField] private GameObject _menuCanvas;
    [SerializeField] private GameObject _selectGunCanvas;

    [Header("MainCameras")]
    [SerializeField] private GameObject _menuCamera;
    [SerializeField] private GameObject _selectGunCamera;

    [SerializeField] private int _currentIndex;


    [SerializeField] private bool IsPistolEquiped;
    [SerializeField] private bool IsSubmachineEquiped;
    [SerializeField] private bool IsShotgunEquiped;
    [SerializeField] private bool IsRifleEquiped;
    [SerializeField] private bool IsSniperEquiped;

    private bool _pistol;
    private bool _submachine;
    private bool _shotgun;
    private bool _rifle;
    private bool _sniper;

    private GetGunOfMenu getGunOfMenu;
    [SerializeField] private Coins Coins;

    private void Awake()
    {
        PlayerPrefs.DeleteAll();
        PlayerPrefs.SetInt("Coins", 10000);
        _moneyAmountText.text = PlayerPrefs.GetInt("Coins").ToString();
        getGunOfMenu = GetComponent<GetGunOfMenu>();
    }

    private void Start()
    {
        Coins = GetComponent<Coins>();
        PlayerPrefs.SetInt("SelectedGun", 0);
        _currentIndex = PlayerPrefs.GetInt("SelectedGun", 0);
        _pistols[_currentIndex].IsBuy = true;
        _pistols[_currentIndex].IsEquiped = true;
        PlayerPrefs.SetBool(_pistols[_currentIndex].WeaponConfig.Name, true);
        _selectedGun = _pistols[_currentIndex].ModelForSelect;
        IsPistolEquiped = true;
    }

    public void SelectPistol()
    {
        _selectTypeOfGunPanel.SetActive(false);
        _selectGunPanel.SetActive(true);
        _pistol = true;
        _currentIndex = PlayerPrefs.GetInt("SelectedGun", 0);
        foreach (WeaponData pistol in _pistols)
        {
            pistol.gameObject.SetActive(false);
        }
        _pistols[_currentIndex].gameObject.SetActive(true);

        _NameOfGun.text = _pistols[_currentIndex].WeaponConfig.Name.ToString();
        _damageOfGun.text = _pistols[_currentIndex].WeaponConfig.Damage.ToString();
        _shootRangeOfGun.text = _pistols[_currentIndex].WeaponConfig.ShootRange.ToString();
        _reloadingOfGun.text = _pistols[_currentIndex].WeaponConfig.ReloadTime.ToString();



        if (_pistols[_currentIndex].IsEquiped)
        {
            _selectGunButton.SetActive(false);
            _equipedGunButton.SetActive(true);
        }else{
            _selectGunButton.SetActive(true);
            _equipedGunButton.SetActive(false);
        }
        _buyGunButton.SetActive(false);
        //_selectedGun = _pistols[_currentIndex].ModelForSelect;
    }

    public void SelectSubmachine()
    {
        _selectTypeOfGunPanel.SetActive(false);
        _selectGunPanel.SetActive(true);
        _submachine = true;
        _currentIndex = PlayerPrefs.GetInt("SelectedGun", 0);
        foreach (WeaponData submachine in _submachines)
        {
            submachine.gameObject.SetActive(false);
        }
        _submachines[_currentIndex].gameObject.SetActive(true);

        _NameOfGun.text = _submachines[_currentIndex].WeaponConfig.Name.ToString();
        _damageOfGun.text = _submachines[_currentIndex].WeaponConfig.Damage.ToString();
        _shootRangeOfGun.text = _submachines[_currentIndex].WeaponConfig.ShootRange.ToString();
        _reloadingOfGun.text = _submachines[_currentIndex].WeaponConfig.ReloadTime.ToString();

        bool purchased = PlayerPrefs.GetBool($"{_submachines[_currentIndex].IsBuy}");

        if (!purchased)
        {
            _priceText.text = _submachines[_currentIndex].WeaponConfig.Price.ToString();
            _buyGunButton.SetActive(true);
            _equipedGunButton.SetActive(false);
            _selectGunButton.SetActive(false);
        }
        else
        {
            if (_submachines[_currentIndex].IsEquiped)
            {
                _selectGunButton.SetActive(false);
                _equipedGunButton.SetActive(true);
            }
            else
            {
                _selectGunButton.SetActive(true);
                _equipedGunButton.SetActive(false);
            }
        }
    }

    public void SelectShotgun()
    {
        _selectTypeOfGunPanel.SetActive(false);
        _selectGunPanel.SetActive(true);
        _shotgun = true;
        _currentIndex = PlayerPrefs.GetInt("SelectedGun", 0);
        foreach (WeaponData shotgun in _shotguns)
        {
            shotgun.gameObject.SetActive(false);
        }
        _shotguns[_currentIndex].gameObject.SetActive(true);

        _NameOfGun.text = _shotguns[_currentIndex].WeaponConfig.Name.ToString();
        _damageOfGun.text = _shotguns[_currentIndex].WeaponConfig.Damage.ToString();
        _shootRangeOfGun.text = _shotguns[_currentIndex].WeaponConfig.ShootRange.ToString();
        _reloadingOfGun.text = _shotguns[_currentIndex].WeaponConfig.ReloadTime.ToString();

        bool purchased = PlayerPrefs.GetBool($"{_shotguns[_currentIndex].WeaponConfig.Name}");

        if (!purchased)
        {
            _priceText.text = _shotguns[_currentIndex].WeaponConfig.Price.ToString();
            _buyGunButton.SetActive(true);
            _equipedGunButton.SetActive(false);
            _selectGunButton.SetActive(false);
        }
        else
        {
            if (_shotguns[_currentIndex].IsEquiped)
            {
                _selectGunButton.SetActive(false);
                _equipedGunButton.SetActive(true);
            }
            else
            {
                _selectGunButton.SetActive(true);
                _equipedGunButton.SetActive(false);
            }
        }
    }
    
    public void SelectRifle()
    {
        _currentIndex = PlayerPrefs.GetInt("SelectedGun", 0);
        _selectTypeOfGunPanel.SetActive(false);
        _selectGunPanel.SetActive(true);
        _rifle = true;
        foreach (WeaponData rifle in _rifles)
        {
            rifle.gameObject.SetActive(false);
        }
        _rifles[_currentIndex].gameObject.SetActive(true);

        _NameOfGun.text = _rifles[_currentIndex].WeaponConfig.Name.ToString();
        _damageOfGun.text = _rifles[_currentIndex].WeaponConfig.Damage.ToString();
        _shootRangeOfGun.text = _rifles[_currentIndex].WeaponConfig.ShootRange.ToString();
        _reloadingOfGun.text = _rifles[_currentIndex].WeaponConfig.ReloadTime.ToString();

        bool purchased = PlayerPrefs.GetBool($"{_rifles[_currentIndex].WeaponConfig.Name}");

        if (!purchased)
        {
            _priceText.text = _rifles[_currentIndex].WeaponConfig.Price.ToString();
            _buyGunButton.SetActive(true);
            _equipedGunButton.SetActive(false);
            _selectGunButton.SetActive(false);
        }
        else
        {
            if (_rifles[_currentIndex].IsEquiped)
            {
                _selectGunButton.SetActive(false);
                _equipedGunButton.SetActive(true);
            }
            else
            {
                _selectGunButton.SetActive(true);
                _equipedGunButton.SetActive(false);
            }
        }
    }
    
    public void SelectSniper()
    {
        _selectTypeOfGunPanel.SetActive(false);
        _selectGunPanel.SetActive(true);
        _sniper = true;
        _currentIndex = PlayerPrefs.GetInt("SelectedGun", 0);
        foreach(WeaponData sniper in _snipers)
        {
            sniper.gameObject.SetActive(false);
        }
        _snipers[_currentIndex].gameObject.SetActive(true);

        _NameOfGun.text = _snipers[_currentIndex].WeaponConfig.Name.ToString();
        _damageOfGun.text = _snipers[_currentIndex].WeaponConfig.Damage.ToString();
        _shootRangeOfGun.text = _snipers[_currentIndex].WeaponConfig.ShootRange.ToString();
        _reloadingOfGun.text = _snipers[_currentIndex].WeaponConfig.ReloadTime.ToString();

        bool purchased = PlayerPrefs.GetBool($"{_snipers[_currentIndex].WeaponConfig.Name}");

        if (!purchased)
        {
            _priceText.text = _snipers[_currentIndex].WeaponConfig.Price.ToString();
            _buyGunButton.SetActive(true);
            _equipedGunButton.SetActive(false);
            _selectGunButton.SetActive(false);
        }
        else
        {
            if (_snipers[_currentIndex].IsEquiped)
            {
                _selectGunButton.SetActive(false);
                _equipedGunButton.SetActive(true);
            }
            else
            {
                _selectGunButton.SetActive(true);
                _equipedGunButton.SetActive(false);
            }
        }
    }

    public void OnClickBackToSelectType()
    {
        foreach (WeaponData pistol in _pistols)
        {
            pistol.gameObject.SetActive(false);
        }
        foreach (WeaponData submachine in _submachines)
        {
            submachine.gameObject.SetActive(false);
        }
        foreach (WeaponData shotgun in _shotguns)
        {
            shotgun.gameObject.SetActive(false);
        }
        foreach (WeaponData rifle in _rifles)
        {
            rifle.gameObject.SetActive(false);
        }
        foreach (WeaponData sniper in _snipers)
        {
            sniper.gameObject.SetActive(false);
        }

        PlayerPrefs.SetInt("SelectedGun", 0);

        _pistol = false;
        _submachine = false;
        _shotgun = false;
        _rifle = false;
        _sniper = false;
        _selectGunPanel.SetActive(false);
        _selectTypeOfGunPanel.SetActive(true);
    }

    public void ChangeNext()
    {
        if (_pistol)
        {
            _pistols[_currentIndex].gameObject.SetActive(false);
            _currentIndex++;
            if (_currentIndex == _pistols.Count)
            {
                _currentIndex = 0;
            }

            _pistols[_currentIndex].gameObject.SetActive(true);

            _NameOfGun.text = _pistols[_currentIndex].WeaponConfig.Name.ToString();
            _damageOfGun.text = _pistols[_currentIndex].WeaponConfig.Damage.ToString();
            _shootRangeOfGun.text = _pistols[_currentIndex].WeaponConfig.ShootRange.ToString();
            _reloadingOfGun.text = _pistols[_currentIndex].WeaponConfig.ReloadTime.ToString();

            bool purchased = PlayerPrefs.GetBool($"{_pistols[_currentIndex].WeaponConfig.Name}");

            if (purchased)
            {
                _buyGunButton.SetActive(false);
                if (_pistols[_currentIndex].IsEquiped)
                {
                    _selectGunButton.SetActive(false);
                    _equipedGunButton.SetActive(true);
                }else{
                    _equipedGunButton.SetActive(false);
                    _selectGunButton.SetActive(true);
                }
            }else{
                _priceText.text = _pistols[_currentIndex].WeaponConfig.Price.ToString();
                _buyGunButton.SetActive(true);
                _selectGunButton.SetActive(false);
                _equipedGunButton.SetActive(false);
            }
            
            //PlayerPrefs.SetInt("SelectedGun", _currentIndex);
        }
        else if (_submachine)
        {
            _submachines[_currentIndex].gameObject.SetActive(false);
            _currentIndex++;
            if (_currentIndex == _submachines.Count)
            {
                _currentIndex = 0;
            }

            _submachines[_currentIndex].gameObject.SetActive(true);

            _NameOfGun.text = _submachines[_currentIndex].WeaponConfig.Name.ToString();
            _damageOfGun.text = _submachines[_currentIndex].WeaponConfig.Damage.ToString();
            _shootRangeOfGun.text = _submachines[_currentIndex].WeaponConfig.ShootRange.ToString();
            _reloadingOfGun.text = _submachines[_currentIndex].WeaponConfig.ReloadTime.ToString();

            bool purchased = PlayerPrefs.GetBool($"{_submachines[_currentIndex].WeaponConfig.Name}");

            if (purchased)
            {
                _buyGunButton.SetActive(false);
                if (_submachines[_currentIndex].IsEquiped)
                {
                    _selectGunButton.SetActive(false);
                    _equipedGunButton.SetActive(true);
                }else{
                    _equipedGunButton.SetActive(false);
                    _selectGunButton.SetActive(true);
                }
            }else{
                _priceText.text = _submachines[_currentIndex].WeaponConfig.Price.ToString();
                _buyGunButton.SetActive(true);
                _selectGunButton.SetActive(false);
                _equipedGunButton.SetActive(false);
            }
            //PlayerPrefs.SetInt("SelectedGun", _currentIndex);
        }
        else if (_shotgun)
        {
            _shotguns[_currentIndex].gameObject.SetActive(false);
            _currentIndex++;
            if (_currentIndex == _shotguns.Count)
            {
                _currentIndex = 0;
            }

            _shotguns[_currentIndex].gameObject.SetActive(true);

            _NameOfGun.text = _shotguns[_currentIndex].WeaponConfig.Name.ToString();
            _damageOfGun.text = _shotguns[_currentIndex].WeaponConfig.Damage.ToString();
            _shootRangeOfGun.text = _shotguns[_currentIndex].WeaponConfig.ShootRange.ToString();
            _reloadingOfGun.text = _shotguns[_currentIndex].WeaponConfig.ReloadTime.ToString();

            bool purchased = PlayerPrefs.GetBool($"{_shotguns[_currentIndex].WeaponConfig.Name}");

            if (purchased)
            {
                _buyGunButton.SetActive(false);
                if (_shotguns[_currentIndex].IsEquiped)
                {
                    _selectGunButton.SetActive(false);
                    _equipedGunButton.SetActive(true);
                }else{
                    _equipedGunButton.SetActive(false);
                    _selectGunButton.SetActive(true);
                }
            }else{
                _priceText.text = _shotguns[_currentIndex].WeaponConfig.Price.ToString();
                _buyGunButton.SetActive(true);
                _selectGunButton.SetActive(false);
                _equipedGunButton.SetActive(false);
            }

            //PlayerPrefs.SetInt("SelectedGun", _currentIndex);
        }
        else if (_rifle)
        {
            _rifles[_currentIndex].gameObject.SetActive(false);
            _currentIndex++;
            if (_currentIndex == _rifles.Count)
            {
                _currentIndex = 0;
            }

            _rifles[_currentIndex].gameObject.SetActive(true);

            _NameOfGun.text = _rifles[_currentIndex].WeaponConfig.Name.ToString();
            _damageOfGun.text = _rifles[_currentIndex].WeaponConfig.Damage.ToString();
            _shootRangeOfGun.text = _rifles[_currentIndex].WeaponConfig.ShootRange.ToString();
            _reloadingOfGun.text = _rifles[_currentIndex].WeaponConfig.ReloadTime.ToString();

            bool purchased = PlayerPrefs.GetBool($"{_rifles[_currentIndex].WeaponConfig.Name}");

            if (purchased)
            {
                _buyGunButton.SetActive(false);
                if (_rifles[_currentIndex].IsEquiped)
                {
                    _selectGunButton.SetActive(false);
                    _equipedGunButton.SetActive(true);
                }else{
                    _equipedGunButton.SetActive(false);
                    _selectGunButton.SetActive(true);
                }
            }else{
                _priceText.text = _rifles[_currentIndex].WeaponConfig.Price.ToString();
                _buyGunButton.SetActive(true);
                _selectGunButton.SetActive(false);
                _equipedGunButton.SetActive(false);
            }

            //PlayerPrefs.SetInt("SelectedGun", _currentIndex);
        }
        else
        {
            _snipers[_currentIndex].gameObject.SetActive(false);
            _currentIndex++;
            if (_currentIndex == _snipers.Count)
            {
                _currentIndex = 0;
            }

            _snipers[_currentIndex].gameObject.SetActive(true);

            _NameOfGun.text = _snipers[_currentIndex].WeaponConfig.Name.ToString();
            _damageOfGun.text = _snipers[_currentIndex].WeaponConfig.Damage.ToString();
            _shootRangeOfGun.text = _snipers[_currentIndex].WeaponConfig.ShootRange.ToString();
            _reloadingOfGun.text = _snipers[_currentIndex].WeaponConfig.ReloadTime.ToString();

            bool purchased = PlayerPrefs.GetBool($"{_snipers[_currentIndex].WeaponConfig.Name}");

            if (purchased)
            {
                _buyGunButton.SetActive(false);
                if (_snipers[_currentIndex].IsEquiped)
                {
                    _selectGunButton.SetActive(false);
                    _equipedGunButton.SetActive(true);
                }else{
                    _equipedGunButton.SetActive(false);
                    _selectGunButton.SetActive(true);
                }
            }else{
                _priceText.text = _snipers[_currentIndex].WeaponConfig.Price.ToString();
                _buyGunButton.SetActive(true);
                _selectGunButton.SetActive(false);
                _equipedGunButton.SetActive(false);
            }
            //PlayerPrefs.SetInt("SelectedGun", _currentIndex);
        }
        PlayerPrefs.SetInt("SelectedGun", _currentIndex);
    }

    public void ChangePrevious()
    {
        if (_pistol)
        {
            _pistols[_currentIndex].gameObject.SetActive(false);
            _currentIndex--;
            if (_currentIndex == -1)
            {
                _currentIndex = _pistols.Count-1;
            }

            _pistols[_currentIndex].gameObject.SetActive(true);

            _NameOfGun.text = _pistols[_currentIndex].WeaponConfig.Name.ToString();
            _damageOfGun.text = _pistols[_currentIndex].WeaponConfig.Damage.ToString();
            _shootRangeOfGun.text = _pistols[_currentIndex].WeaponConfig.ShootRange.ToString();
            _reloadingOfGun.text = _pistols[_currentIndex].WeaponConfig.ReloadTime.ToString();

            bool purchased = PlayerPrefs.GetBool($"{_pistols[_currentIndex].WeaponConfig.Name}");

            if (purchased)
            {
                _buyGunButton.SetActive(false);
                if (_pistols[_currentIndex].IsEquiped)
                {
                    _selectGunButton.SetActive(false);
                    _equipedGunButton.SetActive(true);
                }
                else
                {
                    _equipedGunButton.SetActive(false);
                    _selectGunButton.SetActive(true);
                }
            }
            else
            {
                _priceText.text = _pistols[_currentIndex].WeaponConfig.Price.ToString();
                _buyGunButton.SetActive(true);
                _selectGunButton.SetActive(false);
                _equipedGunButton.SetActive(false);
            }

            //PlayerPrefs.SetInt("SelectedGun", _currentIndex);
        }
        else if (_submachine)
        {
            _submachines[_currentIndex].gameObject.SetActive(false);
            _currentIndex--;
            if (_currentIndex == -1)
            {
                _currentIndex = _submachines.Count-1;
            }

            _submachines[_currentIndex].gameObject.SetActive(true);

            _NameOfGun.text = _submachines[_currentIndex].WeaponConfig.Name.ToString();
            _damageOfGun.text = _submachines[_currentIndex].WeaponConfig.Damage.ToString();
            _shootRangeOfGun.text = _submachines[_currentIndex].WeaponConfig.ShootRange.ToString();
            _reloadingOfGun.text = _submachines[_currentIndex].WeaponConfig.ReloadTime.ToString();

            bool purchased = PlayerPrefs.GetBool($"{_submachines[_currentIndex].WeaponConfig.Name}");

            if (purchased)
            {
                _buyGunButton.SetActive(false);
                if (_submachines[_currentIndex].IsEquiped)
                {
                    _selectGunButton.SetActive(false);
                    _equipedGunButton.SetActive(true);
                }
                else
                {
                    _equipedGunButton.SetActive(false);
                    _selectGunButton.SetActive(true);
                }
            }
            else
            {
                _priceText.text = _submachines[_currentIndex].WeaponConfig.Price.ToString();
                _buyGunButton.SetActive(true);
                _selectGunButton.SetActive(false);
                _equipedGunButton.SetActive(false);
            }

            //PlayerPrefs.SetInt("SelectedGun", _currentIndex);
        }
        else if (_shotgun)
        {
            _shotguns[_currentIndex].gameObject.SetActive(false);
            _currentIndex--;
            if (_currentIndex == -1)
            {
                _currentIndex = _shotguns.Count-1;
            }

            _shotguns[_currentIndex].gameObject.SetActive(true);

            _NameOfGun.text = _shotguns[_currentIndex].WeaponConfig.Name.ToString();
            _damageOfGun.text = _shotguns[_currentIndex].WeaponConfig.Damage.ToString();
            _shootRangeOfGun.text = _shotguns[_currentIndex].WeaponConfig.ShootRange.ToString();
            _reloadingOfGun.text = _shotguns[_currentIndex].WeaponConfig.ReloadTime.ToString();

            bool purchased = PlayerPrefs.GetBool($"{_shotguns[_currentIndex].WeaponConfig.Name}");

            if (purchased)
            {
                _buyGunButton.SetActive(false);
                if (_shotguns[_currentIndex].IsEquiped)
                {
                    _selectGunButton.SetActive(false);
                    _equipedGunButton.SetActive(true);
                }
                else
                {
                    _equipedGunButton.SetActive(false);
                    _selectGunButton.SetActive(true);
                }
            }
            else
            {
                _priceText.text = _shotguns[_currentIndex].WeaponConfig.Price.ToString();
                _buyGunButton.SetActive(true);
                _selectGunButton.SetActive(false);
                _equipedGunButton.SetActive(false);
            }

            //PlayerPrefs.SetInt("SelectedGun", _currentIndex);
        }
        else if (_rifle)
        {
            _rifles[_currentIndex].gameObject.SetActive(false);
            _currentIndex--;
            if (_currentIndex == -1)
            {
                _currentIndex = _rifles.Count-1;
            }

            _rifles[_currentIndex].gameObject.SetActive(true);

            _NameOfGun.text = _rifles[_currentIndex].WeaponConfig.Name.ToString();
            _damageOfGun.text = _rifles[_currentIndex].WeaponConfig.Damage.ToString();
            _shootRangeOfGun.text = _rifles[_currentIndex].WeaponConfig.ShootRange.ToString();
            _reloadingOfGun.text = _rifles[_currentIndex].WeaponConfig.ReloadTime.ToString();

            bool purchased = PlayerPrefs.GetBool($"{_rifles[_currentIndex].WeaponConfig.Name}");

            if (purchased)
            {
                _buyGunButton.SetActive(false);
                if (_rifles[_currentIndex].IsEquiped)
                {
                    _selectGunButton.SetActive(false);
                    _equipedGunButton.SetActive(true);
                }
                else
                {
                    _equipedGunButton.SetActive(false);
                    _selectGunButton.SetActive(true);
                }
            }
            else
            {
                _priceText.text = _rifles[_currentIndex].WeaponConfig.Price.ToString();
                _buyGunButton.SetActive(true);
                _selectGunButton.SetActive(false);
                _equipedGunButton.SetActive(false);
            }

            //PlayerPrefs.SetInt("SelectedGun", _currentIndex);
        }
        else
        {
            _snipers[_currentIndex].gameObject.SetActive(false);
            _currentIndex--;
            if (_currentIndex == -1)
            {
                _currentIndex = _snipers.Count-1;
            }

            _snipers[_currentIndex].gameObject.SetActive(true);

            _NameOfGun.text = _snipers[_currentIndex].WeaponConfig.Name.ToString();
            _damageOfGun.text = _snipers[_currentIndex].WeaponConfig.Damage.ToString();
            _shootRangeOfGun.text = _snipers[_currentIndex].WeaponConfig.ShootRange.ToString();
            _reloadingOfGun.text = _snipers[_currentIndex].WeaponConfig.ReloadTime.ToString();

            bool purchased = PlayerPrefs.GetBool($"{_snipers[_currentIndex].WeaponConfig.Name}");

            if (purchased)
            {
                _buyGunButton.SetActive(false);
                if (_snipers[_currentIndex].IsEquiped)
                {
                    _selectGunButton.SetActive(false);
                    _equipedGunButton.SetActive(true);
                }
                else
                {
                    _equipedGunButton.SetActive(false);
                    _selectGunButton.SetActive(true);
                }
            }
            else
            {
                _priceText.text = _snipers[_currentIndex].WeaponConfig.Price.ToString();
                _buyGunButton.SetActive(true);
                _selectGunButton.SetActive(false);
                _equipedGunButton.SetActive(false);
            }
        }
        PlayerPrefs.SetInt("SelectedGun", _currentIndex);
    }
    
    public void OnClickPlayBackToMenu()
    {
        _selectGunCanvas.SetActive(false);
        _selectGunCamera.SetActive(false);
        _menuCamera.SetActive(true);
        _menuCanvas.SetActive(true);
    }

    public void OnClickSelectGun()
    {
        bool purchased;
        UnequipedGun();

        AudioSource.PlayClipAtPoint(_equipGunSound, Camera.main.transform.position, 50f);

        if (_pistol)
        {
            purchased = PlayerPrefs.GetBool($"{_pistols[_currentIndex].WeaponConfig.Name}");

            if (purchased)
            {
                _pistols[_currentIndex].IsEquiped = true;
                _selectedGun = _pistols[_currentIndex].ModelForSelect;
                IsPistolEquiped = true;
            }
        }else if (_submachine){
            purchased = PlayerPrefs.GetBool($"{_submachines[_currentIndex].WeaponConfig.Name}");

            if (purchased)
            {
                _submachines[_currentIndex].IsEquiped = true;
                _selectedGun = _submachines[_currentIndex].ModelForSelect;
                IsSubmachineEquiped = true;
            }
        }else if (_shotgun){
            purchased = PlayerPrefs.GetBool($"{_shotguns[_currentIndex].WeaponConfig.Name}");

            if (purchased)
            {
                _shotguns[_currentIndex].IsEquiped = true;
                _selectedGun = _shotguns[_currentIndex].ModelForSelect;
                IsShotgunEquiped = true;
            }
        }else if (_rifle){
            purchased = PlayerPrefs.GetBool($"{_rifles[_currentIndex].WeaponConfig.Name}");

            if (purchased)
            {
                _rifles[_currentIndex].IsEquiped = true;
                _selectedGun = _rifles[_currentIndex].ModelForSelect;
                IsRifleEquiped = true;
            }
        }else{
            purchased = PlayerPrefs.GetBool($"{_snipers[_currentIndex].WeaponConfig.Name}");

            if (purchased)
            {
                _snipers[_currentIndex].IsEquiped = true;
                _selectedGun = _snipers[_currentIndex].ModelForSelect;
                IsSniperEquiped = true;
            }
        }
        _selectGunButton.SetActive(false);
        _equipedGunButton.SetActive(true);
    }

    public void OnClickBuyGun()
    {
        int gunPrice = Convert.ToInt32(_priceText.text);
        bool CanBuy = EnoughtCoin(gunPrice);
        if (CanBuy)
        {
            SpendCoins(gunPrice);
            if (_pistol)
            {
                _pistols[_currentIndex].IsBuy = true;
                PlayerPrefs.SetBool(_pistols[_currentIndex].WeaponConfig.Name, true);
            }
            else if (_submachine)
            {
                _submachines[_currentIndex].IsBuy = true;
                PlayerPrefs.SetBool(_submachines[_currentIndex].WeaponConfig.Name, true);
            }
            else if (_shotgun)
            {
                _shotguns[_currentIndex].IsBuy = true;
                PlayerPrefs.SetBool(_shotguns[_currentIndex].WeaponConfig.Name, true);
            }
            else if (_rifle)
            {
                _rifles[_currentIndex].IsBuy = true;
                PlayerPrefs.SetBool(_rifles[_currentIndex].WeaponConfig.Name, true);
            }
            else
            {
                _snipers[_currentIndex].IsBuy = true;
                PlayerPrefs.SetBool(_snipers[_currentIndex].WeaponConfig.Name, true);
            }
            _buyGunButton.SetActive(false);
            _selectGunButton.SetActive(true);
            _equipedGunButton.SetActive(false);

            _moneyAmountText.text = PlayerPrefs.GetInt("Coins").ToString();
            AudioSource.PlayClipAtPoint(_buyGunSound, Camera.main.transform.position, 50f);
        }
        else
        {
            AudioSource.PlayClipAtPoint(_notEnoughtCoinSound, Camera.main.transform.position, 50f);
        }
    }

    public void SetFinalyGunParametres()
    {
        GetGunOfMenu.GunForPlayer = _selectedGun;
        GetGunOfMenu.Pistol = IsPistolEquiped;
        GetGunOfMenu.Submachine = IsSubmachineEquiped;
        GetGunOfMenu.Shotgun = IsShotgunEquiped;
        GetGunOfMenu.Rifle = IsRifleEquiped;
        GetGunOfMenu.Sniper = IsSniperEquiped;
    }

    private void UnequipedGun()
    {
        foreach (WeaponData pistol in _pistols)
        {
            if (pistol.IsEquiped)
            {
                pistol.IsEquiped = false;
            }
        }

        foreach (WeaponData submachine in _submachines)
        {
            if (submachine.IsEquiped)
            {
                submachine.IsEquiped = false;
            }
        }

        foreach (WeaponData shotgun in _shotguns)
        {
            if (shotgun.IsEquiped)
            {
                shotgun.IsEquiped = false;
            }
        }

        foreach (WeaponData rifle in _rifles)
        {
            if (rifle.IsEquiped)
            {
                rifle.IsEquiped = false;
            }
        }

        foreach (WeaponData sniper in _snipers)
        {
            if (sniper.IsEquiped)
            {
                sniper.IsEquiped = false;
            }
        }

        IsPistolEquiped = false;
        IsSubmachineEquiped = false;
        IsShotgunEquiped = false;
        IsRifleEquiped = false;
        IsSniperEquiped = false;
    }

    private bool EnoughtCoin(int amount)
    {
        int coinAmount = PlayerPrefs.GetInt("Coins");
        return coinAmount >= amount;
    }

    private void SpendCoins(int amount)
    {
        int coins = PlayerPrefs.GetInt("Coins");
        coins -= amount;
        PlayerPrefs.SetInt("Coins", coins);
    }

    public void SoundOnClick()
    {
        AudioSource.PlayClipAtPoint(_buttonSound, Camera.main.transform.position, 50f);
    }
}
