using UnityEditor.Experimental.GraphView;
using UnityEngine;

public class AutoShooting : MonoBehaviour
{
    private float _maxRadius = 7f;
    private float _shootCoolDown = 0.5f;
    [SerializeField] private GameObject _egg;
    [SerializeField] private Transform _shootPoint;
    private float _maxDistance;
    float _coolDownTimer;

    public static float _bonusCoolDown;

	void Start()
	{
        _shootCoolDown -= _bonusCoolDown;
	}

	void Update()
    {
        _coolDownTimer -= Time.deltaTime;
        GameObject _target = FindClosestEnemy();

        if(_target != null)
        {
            RotateToTarget(_target);

            if(_coolDownTimer <= 0)
            {
                Shoot();
                _coolDownTimer = _shootCoolDown;
            }
        }
    }

    GameObject FindClosestEnemy()
    {
        GameObject[] _enemies = GameObject.FindGameObjectsWithTag("Enemy");

        GameObject _closestEnemy = null;
        float _minDistance = Mathf.Infinity;

        foreach (GameObject enemy in _enemies)
        {
            float _distance = Vector3.Distance(transform.position, enemy.transform.position);

            if (_distance < _minDistance && _distance < _maxRadius)
            {
                _minDistance = _distance;
                _closestEnemy = enemy;
            }
        }
        return _closestEnemy;
    }

    void RotateToTarget(GameObject target)
    {
        Vector2 _direction = target.transform.position - transform.position;
        float _angle = Mathf.Atan2(_direction.y, _direction.x) * Mathf.Rad2Deg;
        transform.rotation = Quaternion.Euler(0f, 0f, _angle);
    }
    
    void Shoot()
    {
        Instantiate(_egg, _shootPoint.position, _shootPoint.rotation);
    }
}
