using System;
using System.Collections;
using TMPro;
using UnityEngine;
using UnityEngine.UI;

public class Player : MonoBehaviour
{
    [SerializeField] private Slider _hpBar;
    public int _hp = 10;
    public float _maxHp = 10;
    public static int _bonusHp;
    private Animator _animator;
    [SerializeField] private GameObject _deadPanel;
    [SerializeField] private GameObject _pauseButton;
    [SerializeField] private TextMeshProUGUI _hpCount;


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
        if (_hp == 0)
        {
            DeadAnim();
        }
    }
    
    public void AddMaxHp(int _amount)
    {
        _maxHp += _amount;
        _hp += _amount;

        _hpBar.maxValue = _maxHp;
        _hpBar.value = _hp;
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
}
