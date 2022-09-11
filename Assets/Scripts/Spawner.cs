using System.Collections.Generic;
using UnityEngine;
using UnityEngine.Events;

public class Spawner : MonoBehaviour
{
    [SerializeField] private List<Wave> _waves;
    [SerializeField] private Transform _spawnPoint;
    [SerializeField] private Hero _hero;
    [SerializeField] private Transform _flyTarget;

    private Wave _currentWave;
    private int _currentWaveNumber = 0;
    private float _timeAfterLastSpawn;
    private int _spawned;

    public event UnityAction AllEnemySpawned;

    public void NextWave()
    {
        SetWave(++_currentWaveNumber);
        _spawned = 0;
    }

    private void Start()
    {
        SetWave(_currentWaveNumber);
    }

    private void Update()
    {
        if (_currentWave == null)
            return;

        _timeAfterLastSpawn += Time.deltaTime;

        if (_timeAfterLastSpawn >= _currentWave.Delay)
        {
            InstantiateEnemy();
            _spawned++;
            _timeAfterLastSpawn = 0;
        }

        if (_currentWave.Count <= _spawned)
        {
            if (_waves.Count > _currentWaveNumber)
                AllEnemySpawned?.Invoke();

            _currentWave = null;
        }
    }

    private void InstantiateEnemy()
    {
        Enemy enemy = Instantiate(_currentWave.GetTemplate(), _spawnPoint.position, _spawnPoint.rotation, _spawnPoint).GetComponent<Enemy>();
        enemy.Init(_hero);

        if (enemy.TryGetComponent(out Dragon dragon))
            dragon.SetFlyTarget(_flyTarget);

        enemy.Dying += OnEnemyDyieng;
    }

    private void SetWave(int index)
    {
        _currentWave = _waves[index];
    }

    private void OnEnemyDyieng(Enemy enemy)
    {
        enemy.Dying -= OnEnemyDyieng;
        _hero.AddMoney(enemy.Reward);
    }
}

[System.Serializable]

public class Wave
{
    public List<Enemy> Templates;
    public float Delay;
    public int Count;

    public Enemy GetTemplate()
    {
        return Templates[UnityEngine.Random.Range(0, Templates.Count)];
    }
}
