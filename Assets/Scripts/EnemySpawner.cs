using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private List<GameObject> _enemies;
    private float _spawnTime = 3.5f;

    public static float _bonusSpawnTime;

    [SerializeField] private Transform _player;

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
            int _adding = UnityEngine.Random.Range(-10, 10);


            Vector3 _spawnPosition = new Vector3(
                _player.transform.position.x + _adding,
                _player.transform.position.y + _adding,
                0
            );

            Instantiate(_enemy, _spawnPosition, Quaternion.identity);
        }
    }
}
