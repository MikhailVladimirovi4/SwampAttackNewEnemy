using UnityEngine;

public class Dragon : MonoBehaviour
{
    private Transform _flyTargetTransform;

    public Transform FlyTarget => _flyTargetTransform;

    public void SetFlyTarget(Transform pointTransform)
    {
        _flyTargetTransform = pointTransform;
    }
}
