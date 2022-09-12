using System.Collections;
using System.Collections.Generic;
using TMPro;
using UnityEngine;

public class MoneyBalance : MonoBehaviour
{
    [SerializeField] private TMP_Text _money;
    [SerializeField] private Hero _hero;

    private void OnEnable()
    {
        _money.text = _hero.Money.ToString();
    }
}
