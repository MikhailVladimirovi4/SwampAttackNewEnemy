using UnityEngine;

public class FireBall : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private int _damage;
    [SerializeField] private float _angleZ;

    private Hero _target;

    public void Init( Hero target)
    {
        _target = target;
        _target.Dying += Destroy;
        transform.Rotate(0, 0, _angleZ);
    }

    private void Update()
    {
        transform.position = Vector2.MoveTowards(transform.position, _target.transform.position, _speed * Time.deltaTime);
    }

    private void OnCollisionEnter2D(Collision2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Hero hero))
        {
            hero.TakeDamage(_damage);
            Destroy(gameObject);
        }
    }

    private void Destroy()
    {
        _target.Dying -= Destroy;
        Destroy(gameObject);
    }
}
