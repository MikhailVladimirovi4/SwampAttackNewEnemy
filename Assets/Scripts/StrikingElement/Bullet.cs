using UnityEngine;

public class Bullet : StrikingElement
{
    [SerializeField] private Effect _effect;

    private void Update()
    {
        transform.Translate(Vector2.left * Speed * Time.deltaTime, Space.World);
    }

    private void OnTriggerEnter2D(Collider2D collision)
    {
        if (collision.gameObject.TryGetComponent(out Enemy enemy))
        {
            enemy.TakeDamage(Damage);
            Instantiate(_effect, transform.position, Quaternion.identity);
        }

        Destroy(gameObject);
    }

    public override void Init() {}
}
