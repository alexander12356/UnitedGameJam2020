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

        PlayerStats.Instance.CurrentAttackValue1 += _addAttack1Value;
        PlayerStats.Instance.Coins -= _attack1Price;
    }

    public void AddAttackValue2()
    {
        if (PlayerStats.Instance.Coins < _attack2Price)
        {
            return;
        }
       
        PlayerStats.Instance.CurrentAttackValue2 += _addAttack2Value;
        PlayerStats.Instance.Coins -= _attack2Price;
    }
}
