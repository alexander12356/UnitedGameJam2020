using System.Collections;
using System.Collections.Generic;

using MetaGameplay;

using UnityEngine;

public class Store : MonoBehaviour
{
    public int _heal1Price = 0;
    public int _heal2Price = 0;
    
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
        PlayerStats.Instance.Heal1();
    }
}
