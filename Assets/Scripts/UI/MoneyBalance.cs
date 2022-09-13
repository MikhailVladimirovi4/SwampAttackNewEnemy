using TMPro;
using UnityEngine;

public class MoneyBalance : MonoBehaviour
{
    [SerializeField] private TMP_Text _money;
    [SerializeField] private Hero _hero;

    private void OnEnable()
    {
        _money.text = _hero.Money.ToString();
        _hero.MoneyChanged += OnMoneyChanged;
    }

    private void OnDisable()
    {
        _hero.MoneyChanged -= OnMoneyChanged;
    }

    private void OnMoneyChanged(int money)
    {
        _money.text = money.ToString();
    }
}
