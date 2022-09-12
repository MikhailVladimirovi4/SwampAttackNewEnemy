using UnityEngine;

public class HealthBar : Bar
{
    [SerializeField] private Hero _hero;

    private void OnEnable()
    {
        _hero.HealthChanged += OnValueChanged;
        Slider.value = 1;
    }

    private void OnDisable()
    {
        _hero.HealthChanged -= OnValueChanged;
    }
}
