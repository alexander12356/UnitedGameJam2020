using MetaGameplay;

using TMPro;

using UnityEngine;
using UnityEngine.UI;

namespace BR
{
    public class PlayerStatsUI : MonoBehaviour
    {
        [SerializeField] private TMP_Text _hp1Text = null;
        [SerializeField] private TMP_Text _hp2Text = null;
        [SerializeField] private TMP_Text _coinsText = null;
        [SerializeField] private Image _hp1Bar;
        [SerializeField] private Image _hp2Bar;

        void Update()
        {
            var PlayerData = PlayerActor.Instance.Data;
            _hp1Text.text = $"{PlayerData._currentHP1}/{PlayerData._maxHP1}";
            _hp2Text.text = $"{PlayerData._currentHP2}/{PlayerData._maxHP2}";
            _hp1Bar.fillAmount = (float) PlayerData._currentHP1 / PlayerData._maxHP1;
            _hp2Bar.fillAmount = (float) PlayerData._currentHP2 / PlayerData._maxHP2;
            _coinsText.text = $"Coins: {PlayerData.Coins}";
        }
    }
}
