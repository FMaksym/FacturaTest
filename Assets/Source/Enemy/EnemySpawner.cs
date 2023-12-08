using System.Collections.Generic;
using UnityEngine;

public class EnemySpawner : MonoBehaviour
{
    [SerializeField] private int _enemyPoolSize = 10;
    [SerializeField] private GameObject _enemyPrefab;
    [SerializeField] private GameObject _enemyParent;

    [Header("Positions for random spawn")]
    [SerializeField] private Vector2 _minMaxPositionX;
    [SerializeField] private Vector2 _minMaxPositionZ;
    [SerializeField] private Vector2 _minMaxRotationY;

    private List<GameObject> _enemyPool;

    private void Awake()
    {
        InitializeEnemyPool();
    }

    private void Start()
    {
        foreach (var enemy in _enemyPool)
        {
            enemy.SetActive(true);
        }
    }

    private void InitializeEnemyPool()
    {
        _enemyPool = new List<GameObject>();

        for (int i = 0; i < _enemyPoolSize; i++)
        {
            GameObject enemy = Instantiate(_enemyPrefab, RandomSpawnPos(), Quaternion.Euler(RandomRotationY()), _enemyParent.transform);
            enemy.SetActive(false);
            _enemyPool.Add(enemy);
        }
    }

    private Vector3 RandomRotationY() 
    {
        float randomRotationY = Random.Range(_minMaxRotationY.x, _minMaxRotationY.y);
        return new Vector3(0, randomRotationY, 0);
    }

    private Vector3 RandomSpawnPos()
    {
        float randomPosX = Random.Range(_minMaxPositionX.x, _minMaxPositionX.y);
        float randomPosZ = Random.Range(_minMaxPositionZ.x, _minMaxPositionZ.y);
        return new Vector3(randomPosX, 0, randomPosZ);
    }
}
