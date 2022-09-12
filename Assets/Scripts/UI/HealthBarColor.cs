using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(Slider))]

public class HealthBarColor : MonoBehaviour
{
    [SerializeField] private Gradient _gradient;
    [SerializeField] Image _healthBarImage;

    private Slider _slider;

    private void Start()
    {
        _slider = GetComponent<Slider>();
    }

    private void Update()
    {
        if (!_healthBarImage)
            return;

        _healthBarImage.fillAmount = _slider.value;
        _healthBarImage.color = _gradient.Evaluate(_slider.value);
    }
}
