using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Hero : MonoBehaviour
{
    [SerializeField] private int _healt;
    [SerializeField] private List<Weapon> _weapons;
    [SerializeField] private Transform _shootPoint;

    private Weapon _currentWeapon;
    private int _currentHealth;

    public event UnityAction Dying;
    public event UnityAction<int, int> HealthChanged;

    public int Money { get; private set; }

    public void BuyWeapon(Weapon weapon)
    {
        Money -= weapon.Price;
        _weapons.Add(weapon);
    }

    public void TakeDamage(int damage)
    {
        _currentHealth -= damage;
        HealthChanged?.Invoke(_currentHealth, _healt);

        if (_currentHealth <= 0)
        {
            Destroy(gameObject);
            Dying?.Invoke();
        }
    }
    public void AddMoney(int money)
    {
        Money += money;
    }


    private void Start()
    {
        _currentWeapon = _weapons[0];
        _currentHealth = _healt;
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _currentWeapon.Shoot(_shootPoint.transform);
        }
    }
}
