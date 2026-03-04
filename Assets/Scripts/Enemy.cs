using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Player _player;
    private SpriteRenderer _sr;
    private Transform _target;
    public int _enemyHP = 1;

    private LevelCount _levelCount;

    public float _speed = 3.5f;
    private float _minDist = 0.5f;

    public static int _bonusHP = 0;
    public static float _bonusSpeed = 0f;

    void Awake()
    {
        _sr = GetComponent<SpriteRenderer>();
        _player = FindFirstObjectByType<Player>();
        _levelCount = FindFirstObjectByType<LevelCount>();
    }

	void Start()
	{
        _target = _player.transform;
        _enemyHP += _bonusHP;
        _speed += _bonusSpeed;
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
        if (collision.tag == "Player")
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
    
    public void TakeDamage(int _damage)
    {
        _enemyHP -= _damage;

        if(_enemyHP <= 0)
        {
            _levelCount._killedEnemies += 1;
            _player._maxHp += 0.1f;
            Destroy(gameObject);
        }
    }
}
