using UnityEngine;

public class FireBall : MonoBehaviour
{
    [SerializeField] private float _speed;
    [SerializeField] private int _damage;

    private Hero _target;

    public void Init( Hero target)
    {
        _target = target;
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
        }

        Destroy(gameObject);
    }
}
