using System;
using UnityEngine;
using UnityEngine.UI;
using TMPro;

public class PlayerHealth : MonoBehaviour
{
    public bool IsDie;
    public int _playerHealth;

    [SerializeField] private TMP_Text _healthText;
    [SerializeField] private Image _healthBar;
    [SerializeField] private int _fillAmount;
    [SerializeField] private GameObject _hitEffect;
    [SerializeField] private GameObject _LosePanel;
    [SerializeField] private GameObject _InterfacePanel;
    [SerializeField] private GameObject _InputPanel;
    [SerializeField] private UnitHealth unitHealth;
    [SerializeField] private AudioClip playerTakeDamageSound;
    [SerializeField] private AudioClip playerDeathSound;

    private float healthBarFillAmount;
    
    private void Awake()
    {
        unitHealth = GetComponent<UnitHealth>();
    }

    private void Start()
    {
        _playerHealth = unitHealth.Health;
        _healthText.text = _playerHealth.ToString();
    }

    private void Update()
    {
        healthBarFillAmount = (float)_playerHealth / 100;
        _healthBar.fillAmount = healthBarFillAmount;
        _healthText.text = _playerHealth.ToString();
    }

    public void TakingDamage(int damage)
    {
        _playerHealth -= damage;

        AudioSource.PlayClipAtPoint(playerTakeDamageSound, gameObject.transform.position, 100);

        if (_playerHealth <= 0)
        {
            Dead();
        }
    }

    public void AddingHealth(int amount)
    {
        if (_playerHealth < unitHealth.MaxHealth)
        {
            _playerHealth += amount;
            if (_playerHealth > unitHealth.MaxHealth)
            {
                _playerHealth = unitHealth.MaxHealth;
            }
        }
        //if (unitHealth.Health < unitHealth.MaxHealth)
        //{
        //    unitHealth.Health += amount;
        //}
    }

    public void Dead()
    {
        AudioSource.PlayClipAtPoint(playerDeathSound, gameObject.transform.position, 100);
        Time.timeScale = 0;
        IsDie = true;
        //Cursor.lockState = CursorLockMode.Locked;
        _LosePanel.SetActive(true);
        _InterfacePanel.SetActive(false);
        _InputPanel.SetActive(false);
    }
}
