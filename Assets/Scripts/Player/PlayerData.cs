using System;

using CommandPattern;

using UnityEngine;

namespace BR
{
	public class PlayerData : MonoBehaviour
	{
		[SerializeField] private int _maxHP1 = 0;
		[SerializeField] private int _maxHP2 = 0;
		public int _currentHP1 = 0;
		public int _currentHP2 = 0;

		private IActor _actor;

		private void Awake()
		{
			_actor = GetComponent<IActor>();
		}

		public void Damage(int value, DamageType damageType)
		{
			switch (damageType)
			{
				case DamageType.Type1:
					_currentHP1 -= value;

					break;
				case DamageType.Type2:
					_currentHP2 -= value;

					break;
			}

			if (_currentHP1 <= 0 || _currentHP2 <= 0)
			{
				_actor.Death();
			}
		}

		public void ResetData()
		{
			_currentHP1 = _maxHP1;
			_currentHP2 = _maxHP2;
		}
	}
}