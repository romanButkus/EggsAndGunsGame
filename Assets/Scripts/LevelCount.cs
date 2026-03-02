using System;
using TMPro;
using UnityEngine;
using UnityEngine.SceneManagement;

public class LevelCount : MonoBehaviour
{
    [SerializeField] private TextMeshProUGUI _waveCountText;
    public int _wave = 1;
    public int _killedEnemies = 0;
    public int _needKills;

    [SerializeField] private GameObject _lvlCompPanel;

    private EggShot _eggshot;
    private Enemy _enemy;
    private EnemySpawner _enemySpawner;

	void Update()
    {
        _waveCountText.text = Convert.ToString(_wave);
    }

	void FixedUpdate()
	{
		if(_killedEnemies >= _needKills)
        {
            Time.timeScale = 0;
            _lvlCompPanel.SetActive(true);
        }
	}

	public void NextLevel()
    {
        Time.timeScale = 1;
        _wave++;
        _killedEnemies = 0;
        _needKills = _wave * 10;

        _lvlCompPanel.SetActive(false);

    }
}
