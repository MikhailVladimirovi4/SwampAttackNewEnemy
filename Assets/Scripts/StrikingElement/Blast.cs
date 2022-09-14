using System.Collections;
using UnityEngine;

[RequireComponent(typeof(Animator))]
[RequireComponent(typeof(CircleCollider2D))]

public class Blast : MonoBehaviour
{
    [SerializeField] private float _delayTime;
    [SerializeField] private float _blastRadiys;

    private Animator _animator;
    private CircleCollider2D _circleCollider;
    private WaitForSeconds _spawnPause;

    private void OnEnable()
    {
        _animator = GetComponent<Animator>();
        _spawnPause = new WaitForSeconds(_delayTime);
        _circleCollider = GetComponent<CircleCollider2D>();
    }

    public IEnumerator GetBlast()
    {
        _animator.SetBool(AnimatorRocketController.Params.ReachedTarget, true);
        _circleCollider.radius = _blastRadiys;

        yield return _spawnPause;

        Destroy(gameObject);
    }
}
