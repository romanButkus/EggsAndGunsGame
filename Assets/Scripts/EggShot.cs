using UnityEngine;

public class EggShot : MonoBehaviour
{
    public float _speed = 15f;
    public float _lifeTime = 2f;

    public static float _bonusSpeedEgg;

    void Start()
    {
        _speed += _bonusSpeedEgg;
        Destroy(gameObject, _lifeTime);
    }

    void Update()
    {
        transform.Translate(Vector2.right * _speed * Time.deltaTime);
    }

	void OnTriggerEnter2D(Collider2D collision)
	{
        if (collision.tag == "Enemy")
        {
            Enemy _enemy = collision.GetComponent<Enemy>();
            
            Destroy(gameObject);
            _enemy.TakeDamage(1);
        }
	}
}
