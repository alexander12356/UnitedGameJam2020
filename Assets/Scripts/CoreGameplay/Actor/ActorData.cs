using System;

using BR.Actor;

using CommandPattern;

using UnityEngine;

namespace BR
{
	public class ActorData : MonoBehaviour, IActorData
	{
		public int _maxHP1 = 0;
		public int _maxHP2 = 0;
		public int _currentHP1 = 0;
		public int _currentHP2 = 0;

		public int MeleeAttackValue1;
		public int MeleeAttackValue2;
		public int RangeAttackValue1;
		public int RangeAttackValue2;
		public float MeleeAttack1Delay = 0;
		public float MeleeAttack2Delay = 0;
		public float AttackDistance = 0;
		public Vector2 DamageForce = Vector2.zero;

		public float RangeAttackFrequency = 0f;
		public int Coins = 0;

		private IActor _actor;

		private void Awake()
		{
			_actor = GetComponent<IActor>();
		}

		public virtual void Damage(int value, DamageType damageType)
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

		public int GetMeleeDamageValue(DamageType type)
		{
			switch (type)
			{
				case DamageType.Type1:
					return MeleeAttackValue1;
				case DamageType.Type2:
					return MeleeAttackValue2;
			}

			return 0;
		}

		public int GetRangeDamageValue(DamageType type)
		{
			switch (type)
			{
				case DamageType.Type1:
					return RangeAttackValue1;
				case DamageType.Type2:
					return RangeAttackValue2;
			}

			return 0;
		}
	}
}