using UnityEngine;

public class Enemy : MonoBehaviour
{
    private Player _player;
    private SpriteRenderer _sr;
    private Transform _target;

    [SerializeField] private float _speed = 2f;
    private float _minDist = 1f;

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
        transform.LookAt(_target);

        float _distance = Vector3.Distance(transform.position, _target.position);

        if (_distance > _minDist)
        {
            transform.position += transform.forward * _speed * Time.deltaTime;
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

    void OnTriggerEnter2D(Collider2D _collision)
    {
        if (_collision.transform.tag == "Player")
        {
            _player._hp -= 1;
        }
    }
}
