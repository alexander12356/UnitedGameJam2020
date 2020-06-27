using System;
using System.Collections;
using System.Collections.Generic;

using MetaGameplay;

using TMPro;

using UnityEngine;
using UnityEngine.UI;

public class PlayerStatsUI : MonoBehaviour
{
    [SerializeField] private TMP_Text _hp1Text = null;
    [SerializeField] private TMP_Text _hp2Text = null;
    [SerializeField] private TMP_Text _coinsText = null;
    [SerializeField] private Image _hp1Bar;
    [SerializeField] private Image _hp2Bar;
    [SerializeField] private TMP_Text _attack1Text = null;
    [SerializeField] private TMP_Text _attack2Text = null;

    private void Awake()
    {
        if (PlayerStats.Instance == null)
        {
            new GameObject().AddComponent<PlayerStats>();
        }
    }

    // Update is called once per frame
    void Update()
    {
        _hp1Text.text = $"{PlayerStats.Instance.CurrentHP1}/{PlayerStats.Instance.MaxHP1}";
        _hp2Text.text = $"{PlayerStats.Instance.CurrentHP2}/{PlayerStats.Instance.MaxHP2}";
        _hp1Bar.fillAmount = (float) PlayerStats.Instance.CurrentHP1 / PlayerStats.Instance.MaxHP1;
        _hp2Bar.fillAmount = (float) PlayerStats.Instance.CurrentHP2 / PlayerStats.Instance.MaxHP2;
        _coinsText.text = $"Coins: {PlayerStats.Instance.Coins}";
        _attack1Text.text = $"Attack1: {PlayerStats.Instance.MeleeAttackValue1}";
        _attack2Text.text = $"Attack2: {PlayerStats.Instance.MeleeAttackValue2}";
    }
}
