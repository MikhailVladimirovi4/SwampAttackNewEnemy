using UnityEngine;
using UnityEngine.UI;

[RequireComponent(typeof(RawImage))]

public class SkyParalax : MonoBehaviour
{
    [SerializeField] private float _speed;

    private RawImage _rawImage;
    private float _imagePositionX;

    private void Start()
    {
        _rawImage = GetComponent<RawImage>();
    }

    private void Update()
    {
        _imagePositionX += _speed * Time.deltaTime;
        _rawImage.uvRect = new Rect(_imagePositionX, 0, _rawImage.uvRect.width, _rawImage.uvRect.height);
    }
}
