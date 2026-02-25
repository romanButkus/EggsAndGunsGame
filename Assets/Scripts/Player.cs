using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private Slider _hpBar;
    [SerializeField] public int _hp;
    private Animator _animator;
    [SerializeField] private GameObject _deadPanel;
    [SerializeField] private GameObject _pauseButton;
    [SerializeField] private TextMeshProUGUI _hpCount;
    [SerializeField] private GameObject _egg;

    void Awake()
    {
        _animator = GetComponent<Animator>();
    }

	void Start()
	{
        _animator.SetBool("isDead", false);
	}

	void Update()
	{
        _hpBar.value = _hp;
        _hpCount.text = Convert.ToString(_hp);
        if(_hp == 0)
        {
            DeadAnim();
        }
	}

    public void TakeDamage()
    {
        _hp -= 1;
    }

    void DeadAnim()
    {
        _animator.SetBool("isDead", true);
        StartCoroutine(WaitForDeathAnim());
    }

    IEnumerator WaitForDeathAnim()
    {
        yield return new WaitForSeconds(_animator.GetCurrentAnimatorStateInfo(0).length);
        Time.timeScale = 0;
        _deadPanel.SetActive(true);
        _pauseButton.SetActive(false);
    }
    
    void Shoot()
    {
        
    }
}
