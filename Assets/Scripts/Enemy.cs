using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Player _player;
    private SpriteRenderer _sr;
    private Transform _target;

    [SerializeField] private float _speed = 2f;
    private float _minDist = 0.5f;

    void Awake()
    {
        _sr = GetComponent<SpriteRenderer>();
        _player = FindFirstObjectByType<Player>();
    }

	void Start()
	{
        _target = _player.transform;
	}

    void Update()
    {
        Vector2 _direction = (_target.transform.position - transform.position).normalized;

        float _distance = Vector3.Distance(transform.position, _target.position);

        if (_distance > _minDist)
        {
            transform.position += (Vector3)_direction * _speed * Time.deltaTime;
        }

        float _playerPositionX = _player.transform.position.x;
        float _enemyPosX = transform.position.x;

        if (_playerPositionX > _enemyPosX)
        {
            _sr.flipX = false;
        }
        else
        {
            _sr.flipX = true;
        }
    }

	void OnTriggerEnter2D(Collider2D collision)
	{
		if(collision.tag == "Player")
        {
            if (_player._hp == 0)
            {
                _speed = 0;
            }
            else
            {
                _player.TakeDamage();
            }
        }
	}
}
