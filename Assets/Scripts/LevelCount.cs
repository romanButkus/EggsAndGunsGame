using System;
using TMPro;
using UnityEngine;

public class LevelCount : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _waveCountText;
    public int _wave;
    public int _killedEnemies = 0;
    public int _needKills;

    [SerializeField] private GameObject _lvlCompPanel;

    [SerializeField] private Transform _player;

	void Start()
	{
        _needKills = _wave * 10;
	}

	void Update()
    {
        _waveCountText.text = Convert.ToString(_wave);
    }

    void FixedUpdate()
    {
        if (_killedEnemies >= _needKills)
        {
            Time.timeScale = 0;
            _lvlCompPanel.SetActive(true);
        }
    }
    
    public void NextLevelChanges()
    {
        Time.timeScale = 1;
        _wave++;
        _killedEnemies = 0;

        _player.transform.position = new Vector3(0, 0);

        Enemy._bonusHP += 1;
        Enemy._bonusSpeed += 0.2f;

        EggShot._bonusSpeedEgg += 1f;

        EnemySpawner._bonusSpawnTime += 0.35f;

        _lvlCompPanel.SetActive(false);
    }

    public void NextLevel()
    {
        if (_wave == 10)
        {
            Time.timeScale = 1;
            _wave++;
            _killedEnemies = 0;

            _player.transform.position = new Vector3(0, 0);

            _lvlCompPanel.SetActive(false);
        }
        else
        {
            NextLevelChanges();
        }
    }
}
