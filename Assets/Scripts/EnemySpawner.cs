using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> _enemies;
    private float _spawnTime = 1f;

    public static float _bonusSpawnTime;

    [SerializeField] private Transform _player;

    private float _minDistance = 5f;
    private float _maxDistance = 10f;

    void Start()
    {
        _spawnTime += _bonusSpawnTime;
        StartCoroutine(SpawnEnemy());
    }

    IEnumerator SpawnEnemy()
    {
        while (true)
        {

            yield return new WaitForSeconds(_spawnTime);
            GameObject _enemy = _enemies[UnityEngine.Random.Range(0, _enemies.Count)];
            Vector2 _randomDirection = Random.insideUnitCircle.normalized;
            float _randomDistance = Random.Range(_minDistance, _maxDistance);


            Vector3 _spawnPosition = _player.position + (Vector3)(_randomDirection * _randomDistance);

            Instantiate(_enemy, _spawnPosition, Quaternion.identity);
        }
    }
}
