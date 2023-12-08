using System.Collections.Generic;
using UnityEngine;
using Zenject;

public class TurretShooting : MonoBehaviour
{
    [SerializeField] private float _fireRate;
    [SerializeField] private float _maxFireDistance;
    [SerializeField] private Transform _firePoint;
    [SerializeField] private GameObject _bulletPrefab;
    [SerializeField] private GameObject _bulletParent;
    [SerializeField] private CarVFX _carVFX;

    private int _bulletPoolSize = 15;
    private float _nextFireTime = 0.0f;
    private List<GameObject> _bulletPool;

    [Inject] GameManager _gameManager;

    private void Awake()
    {
        InitializeBulletPool();
    }

    private void Update()
    {
        if (_gameManager.IsGame())
        {
            if (Time.time >= _nextFireTime)
            {
                _nextFireTime = Time.time + _fireRate;
                Shoot();
            }
        }
    }

    private void Shoot()
    {
        GameObject bullet = GetInactiveBullet();
        if (bullet)
        {
            bullet.transform.position = _firePoint.position;
            bullet.transform.rotation = _firePoint.rotation;
            bullet.SetActive(true);
            _carVFX.ShootTurret();
            return;
        }
    }

    private void InitializeBulletPool()
    {
        _bulletPool = new List<GameObject>();

        for (int i = 0; i < _bulletPoolSize; i++)
        {
            GameObject bullet = Instantiate(_bulletPrefab, _bulletParent.transform);
            bullet.SetActive(false);
            _bulletPool.Add(bullet);
        }
    }

    private GameObject GetInactiveBullet()
    {
        foreach (GameObject bullet in _bulletPool)
        {
            if (!bullet.activeInHierarchy)
            {
                return bullet;
            }
        }
        return null;
    }
}
