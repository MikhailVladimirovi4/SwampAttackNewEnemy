using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(SpriteRenderer))]

public class Hero : MonoBehaviour
{
    [SerializeField] private int _healt;
    [SerializeField] private List<Weapon> _weapons;
    [SerializeField] private Transform _shootPoint;
    [SerializeField] private List<Sprite> _sprites;

    private Weapon _currentWeapon;
    private int _currentWeaponIndex = 0;
    private int _currentHealth;
    private Animator _animator;
    private SpriteRenderer _spriteRenderer;
    private readonly int _spriteRobotIndex = 1;

    public event UnityAction Dying;
    public event UnityAction<int> MoneyChanged;
    public event UnityAction<int, int> HealthChanged;

    public int Money { get; private set; }

    public void NextWeapon()
    {
        if (_currentWeaponIndex == _weapons.Count - 1)
            _currentWeaponIndex = 0;
        else
            _currentWeaponIndex++;

        if (_currentWeaponIndex == _spriteRobotIndex)
            _animator.enabled = false;
        else
            _animator.enabled = true;

        ChangeWeapon(_weapons[_currentWeaponIndex]);
        ChangeSprite(_sprites[_currentWeaponIndex]);
    }

    public void PreviousWeapon()
    {
        if (_currentWeaponIndex == 0)
            _currentWeaponIndex = _weapons.Count - 1;
        else
            _currentWeaponIndex--;

        if (_currentWeaponIndex == _spriteRobotIndex)
            _animator.enabled = false;
        else
            _animator.enabled = true;

        ChangeWeapon(_weapons[_currentWeaponIndex]);
        ChangeSprite(_sprites[_currentWeaponIndex]);
    }

    public void BuyWeapon(Weapon weapon)
    {
        Money -= weapon.Price;
        MoneyChanged?.Invoke(Money);
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
        MoneyChanged?.Invoke(Money);
    }


    private void Start()
    {
        ChangeWeapon(_weapons[_currentWeaponIndex]);
        _currentHealth = _healt;
        _animator = GetComponent<Animator>();
        _spriteRenderer = GetComponent<SpriteRenderer>();
    }

    private void Update()
    {
        if (Input.GetMouseButtonDown(0))
        {
            _currentWeapon.Shoot(_shootPoint.transform);
            _animator.SetTrigger(AnimatorHeroController.Params.Shoot);
        }
    }

    private void ChangeWeapon(Weapon weapon)
    {
        _currentWeapon = weapon;
    }

    private void ChangeSprite(Sprite sprite)
    {
            _spriteRenderer.sprite = sprite;
    }
}
