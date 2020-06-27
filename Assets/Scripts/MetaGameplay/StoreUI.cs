using System.Collections;
using System.Collections.Generic;

using TMPro;

using UnityEngine;

public class StoreUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _heal1Price;
    [SerializeField] private TMP_Text _heal2Price;
    [SerializeField] private TMP_Text _maxHP1Price;
    [SerializeField] private TMP_Text _maxHP2Price;
    [SerializeField] private TMP_Text _meleeAttack1Price;
    [SerializeField] private TMP_Text _meleeAttack2Price;
    [SerializeField] private TMP_Text _rangeAttack1Price;
    [SerializeField] private TMP_Text _rangeAttack2Price;

    void Update()
    {
        _heal1Price.text = $"Coin {Store.Instance._heal1Price}";
        _heal2Price.text = $"Coin {Store.Instance._heal2Price}";
        _maxHP1Price.text = $"Coin {Store.Instance._maxHP1Price}";
        _maxHP2Price.text = $"Coin {Store.Instance._maxHP2Price}";
        _meleeAttack1Price.text = $"Coin {Store.Instance._attack1Price}";
        _meleeAttack2Price.text = $"Coin {Store.Instance._attack2Price}";
        _rangeAttack1Price.text = $"Coin {Store.Instance._rangeAttack1Price}";
        _rangeAttack2Price.text = $"Coin {Store.Instance._rangeAttack2Price}";
    }
}
