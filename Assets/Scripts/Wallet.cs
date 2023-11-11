using System;
using System.Collections;
using UnityEngine;

public class Wallet : Singleton<Wallet>
{
    private int _money = 150;

    public static Action<int> onChangedMoney;

    private int _moneyPerSec = 15;

    public int GetMoney() => _money;

    private void OnEnable() => MineTower.onBuiltMine += UpdateMoneyPerSec;
    private void OnDisable() => MineTower.onBuiltMine -= UpdateMoneyPerSec;

    private void Start()
    {
        StartCoroutine(MoneyPerSec());
    }

    private void Update()
    {
        if(Input.GetKeyDown(KeyCode.P))
            AddMoney(50); 
    }

    public void AddMoney(int _value) 
    {
        if(_value > 0)
        {
            _money += _value;
        }
        UIUpdateMoney();
    }
    public void RemoveMoney(int _value)
    {
        if(_value > 0)
        {
            _money -= _value;
        }
        UIUpdateMoney();
    }

    public void UIUpdateMoney()
    {
        onChangedMoney?.Invoke(_money);
    }

    public int GetMoneyPerSec() => _moneyPerSec;

    public void UpdateMoneyPerSec(int value)
    {
        _moneyPerSec += value;
    }

    private IEnumerator MoneyPerSec()
    {
        while(true)
        {
            AddMoney(_moneyPerSec); 
            yield return new WaitForSeconds(1f);
        }
    }
}   
