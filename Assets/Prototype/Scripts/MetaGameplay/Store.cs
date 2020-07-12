using System;

using MetaGameplay;

using UnityEngine;

public class Store : MonoBehaviour
{
    public static Store Instance = null;

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

    public int BasePrice = 0;
    public int Heal1Stage = 0;
    public int Heal2Stage = 0;
    public int Melee1AttackStage = 1;
    public int Melee2AttackStage = 1;
    public int Range1AttackStage = 1;
    public int Range2AttackStage = 1;
    public int MaxHP1Stage = 1;
    public int MaxHP2Stage = 1;

    private void Awake()
    {
        Instance = this;
    }

    private void Start()
    {
        _heal1Price = BasePrice * PlayerStats.Instance.HealStage1;
        _heal2Price = BasePrice * PlayerStats.Instance.HealStage2;
        _attack1Price = BasePrice * PlayerStats.Instance.MeleeAttackStage1;
        _attack2Price = BasePrice * PlayerStats.Instance.MeleeAttackStage2;
        _maxHP1Price = MaxHP1Stage * PlayerStats.Instance.MaxHPStage1;
        _maxHP2Price = MaxHP2Stage * PlayerStats.Instance.MaxHPStage2;
        _rangeAttack1Price = BasePrice * PlayerStats.Instance.RangeAttackStage1;
        _rangeAttack2Price = BasePrice * PlayerStats.Instance.RangeAttackStage2;
    }

    public void GoPhysicWorld()
    {
        Save();
        GameCycle.Instance.CloseStore(0);
    }

    public void GoSpecterWorld()
    {
        Save();
        GameCycle.Instance.CloseStore(1);
    }

    private void Save()
    {
        PlayerStats.Instance.HealStage1 = Heal1Stage;
        PlayerStats.Instance.HealStage2 = Heal2Stage;
        
        PlayerStats.Instance.MaxHPStage1 = MaxHP1Stage;
        PlayerStats.Instance.MaxHPStage2 = MaxHP2Stage;

        PlayerStats.Instance.MeleeAttackStage1 = Melee1AttackStage;
        PlayerStats.Instance.MeleeAttackStage2 = Melee2AttackStage;
        
        PlayerStats.Instance.RangeAttackStage1 = Range1AttackStage;
        PlayerStats.Instance.RangeAttackStage2 = Range2AttackStage;
    }

    public void Heal1()
    {
        if (PlayerStats.Instance.Coins < _heal1Price || PlayerStats.Instance.CurrentHP1 == PlayerStats.Instance.MaxHP1)
        {
            return;
        }

        PlayerStats.Instance.Coins -= _heal1Price;
        PlayerStats.Instance.Heal1();

        Heal1Stage++;
        _heal1Price = BasePrice * Heal1Stage;
    }
    
    public void Heal2()
    {
        if (PlayerStats.Instance.Coins < _heal2Price || PlayerStats.Instance.CurrentHP2 == PlayerStats.Instance.MaxHP2)
        {
            return;
        }
        
        PlayerStats.Instance.Coins -= _heal2Price;
        PlayerStats.Instance.Heal2();
        
        Heal2Stage++;
        _heal2Price = BasePrice * Heal2Stage;
    }

    public void AddAttackValue1()
    {
        if (PlayerStats.Instance.Coins < _attack1Price)
        {
            return;
        }

        PlayerStats.Instance.MeleeAttackValue1 += _addAttack1Value;
        PlayerStats.Instance.Coins -= _attack1Price;
        
        Melee1AttackStage++;
        _attack1Price = BasePrice * Melee1AttackStage;
    }

    public void AddAttackValue2()
    {
        if (PlayerStats.Instance.Coins < _attack2Price)
        {
            return;
        }
       
        PlayerStats.Instance.MeleeAttackValue2 += _addAttack2Value;
        PlayerStats.Instance.Coins -= _attack2Price;
        
        Melee2AttackStage++;
        _attack2Price = BasePrice * Melee2AttackStage;
    }

    public void AddMaxHP1()
    {
        if (PlayerStats.Instance.Coins < _maxHP1Price)
        {
            return;
        }

        var currentHp = PlayerStats.Instance.CurrentHP1;
        var maxHP = PlayerStats.Instance.MaxHP1;
        var percent = Convert.ToInt32((currentHp * 100) / (float)maxHP);
       
        PlayerStats.Instance.MaxHP1 += _addMaxHP1;
        PlayerStats.Instance.CurrentHP1 = Convert.ToInt32(PlayerStats.Instance.MaxHP1 * percent / 100f);
        PlayerStats.Instance.Coins -= _maxHP1Price;
        
        MaxHP1Stage++;
        _maxHP1Price = MaxHP1Stage * BasePrice;
    }
 
    public void AddMaxHP2()
    {
        if (PlayerStats.Instance.Coins < _maxHP2Price)
        {
            return;
        }

        var currentHp = PlayerStats.Instance.CurrentHP2;
        var maxHP = PlayerStats.Instance.MaxHP2;
        var percent = Convert.ToInt32((currentHp * 100) / (float)maxHP);
       
        PlayerStats.Instance.MaxHP2 += _addMaxHP2;
        PlayerStats.Instance.CurrentHP2 = Convert.ToInt32(PlayerStats.Instance.MaxHP2 * percent / 100f);
        PlayerStats.Instance.Coins -= _maxHP2Price;
        
        MaxHP2Stage++;
        _maxHP2Price = MaxHP2Stage * BasePrice;
    }

    public void AddRangeAttack1()
    {
        if (PlayerStats.Instance.Coins < _rangeAttack1Price)
        {
            return;
        }
       
        PlayerStats.Instance.RangeAttackValue1 += _addRangeAttack1Value;
        PlayerStats.Instance.Coins -= _rangeAttack1Price;
        
        Range1AttackStage++;
        _rangeAttack1Price = BasePrice * Range1AttackStage;
    }

    public void AddRangeAttack2()
    {
        if (PlayerStats.Instance.Coins < _rangeAttack2Price)
        {
            return;
        }
       
        PlayerStats.Instance.RangeAttackValue2 += _addRangeAttack2Value;
        PlayerStats.Instance.Coins -= _rangeAttack2Price;
        
        Range2AttackStage++;
        _rangeAttack2Price = BasePrice * Range2AttackStage;
    }
}
