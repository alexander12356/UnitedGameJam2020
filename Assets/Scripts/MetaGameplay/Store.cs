using System.Collections;
using System.Collections.Generic;

using MetaGameplay;

using UnityEngine;

public class Store : MonoBehaviour
{
    public int _heal1Price = 0;
    public int _heal2Price = 0;
    public int _attack1Price = 0;
    public int _attack2Price = 0;
    public int _addAttack1Value = 0;
    public int _addAttack2Value = 0;
    public int _addMaxHP1 = 0;
    public int _addMaxHP2 = 0;
    public int _maxHP1Price = 0;
    public int _maxHP2Price = 0;
    public int _rangeAttack1Price = 0;
    public int _rangeAttack2Price = 0;
    public int _addRangeAttack1Value = 0;
    public int _addRangeAttack2Value = 0;
    
    public void CloseStore()
    {
        GameCycle.Instance.CloseStore();
    }

    public void Heal1()
    {
        if (PlayerStats.Instance.Coins < _heal1Price)
        {
            return;
        }

        PlayerStats.Instance.Coins -= _heal1Price;
        PlayerStats.Instance.Heal1();
    }
    
    public void Heal2()
    {
        if (PlayerStats.Instance.Coins < _heal2Price)
        {
            return;
        }

        PlayerStats.Instance.Coins -= _heal2Price;
        PlayerStats.Instance.Heal2();
    }

    public void AddAttackValue1()
    {
        if (PlayerStats.Instance.Coins < _attack1Price)
        {
            return;
        }

        PlayerStats.Instance.MeleeAttackValue1 += _addAttack1Value;
        PlayerStats.Instance.Coins -= _attack1Price;
    }

    public void AddAttackValue2()
    {
        if (PlayerStats.Instance.Coins < _attack2Price)
        {
            return;
        }
       
        PlayerStats.Instance.MeleeAttackValue2 += _addAttack2Value;
        PlayerStats.Instance.Coins -= _attack2Price;
    }

    public void AddMaxHP1()
    {
        if (PlayerStats.Instance.Coins < _maxHP1Price)
        {
            return;
        }
       
        PlayerStats.Instance.MaxHP1 += _addMaxHP1;
        PlayerStats.Instance.Coins -= _maxHP1Price;
    }
 
    public void AddMaxHP2()
    {
        if (PlayerStats.Instance.Coins < _maxHP2Price)
        {
            return;
        }
       
        PlayerStats.Instance.MaxHP2 += _addMaxHP2;
        PlayerStats.Instance.Coins -= _maxHP2Price;
    }

    public void AddRangeAttack1()
    {
        if (PlayerStats.Instance.Coins < _rangeAttack1Price)
        {
            return;
        }
       
        PlayerStats.Instance.RangeAttackValue1 += _addRangeAttack1Value;
        PlayerStats.Instance.Coins -= _rangeAttack1Price;
    }

    public void AddRangeAttack2()
    {
        if (PlayerStats.Instance.Coins < _rangeAttack2Price)
        {
            return;
        }
       
        PlayerStats.Instance.RangeAttackValue2 += _addRangeAttack2Value;
        PlayerStats.Instance.Coins -= _rangeAttack2Price;
    }
}
