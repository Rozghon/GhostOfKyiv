using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using UnityEngine.UI;

public class HealthController : MonoBehaviour
{
    [SerializeField] private int _health;
    [SerializeField] private int _healthRegen;
    [SerializeField] private float _regenDelay = 10f;
    [SerializeField] private Slider _healthBar;

    private int _curentHealth;
    private int _startingHealth;

    private bool _isRegenStarted = false;

    private void Awake()
    {
        _curentHealth = _health;
        UpdateHealthBar();
    }

    private void Update()
    {
        if(!_isRegenStarted)
        {
            StartCoroutine(HealthRegen(_regenDelay));
        }
    }

    public void SetStartingStats()
    {
        _startingHealth = _health;
    }

    public int GetCurentHealth()
    {
        return _curentHealth;
    }

    public int GetMaxHealth()
    {
        return _health;
    }

    public void SetMaxHealth()
    {
        int _level = GameRuller.instance.GetLevel();
        _health = _startingHealth + (int)((float)_level * 0.3f);
        _curentHealth = _health;
    }

    public void SetHealth(int _value)
    {
        _health = _value;
        _curentHealth = _health;
        _startingHealth = _value;
    }

    public void SetRegen(int _value)
    {
        _healthRegen = _value;
    }

    public void Heal(int _value)
    {
        _curentHealth += _value;

        if(_curentHealth > _health)
        {
            _curentHealth = _health;
        }
        UpdateHealthBar();
    }

    public void GetDamage(int _value)
    {
        _curentHealth -= _value;
        UpdateHealthBar();
    }

    public void UpHealth(int _value)
    {
        _health += _value;
        _curentHealth += _value;
        UpdateHealthBar();
    }

    private void UpdateHealthBar()
    {
        if (_healthBar != null)
        {
            _healthBar.maxValue = _health;
            _healthBar.value = _curentHealth;
        }
    }

    public void FindPlayerHPBar()
    {
        _healthBar = GameObject.FindGameObjectWithTag("PlayerSlider").GetComponent<Slider>();
    }

    public void FindSityHPBar()
    {
        _healthBar = GameObject.FindGameObjectWithTag("SitySlider").GetComponent<Slider>();
    }

    private IEnumerator HealthRegen(float _value)
    {
        _isRegenStarted = true;

        yield return new WaitForSeconds(_value);
        Heal(_healthRegen);

        _isRegenStarted = false;
    }
}