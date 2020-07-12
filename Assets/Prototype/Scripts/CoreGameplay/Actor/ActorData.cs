using System;

using BR.Actor;

using CommandPattern;

using UnityEngine;
using UnityEngine.Serialization;

namespace BR
{
	public class ActorData : MonoBehaviour, IActorData
	{
		public int _maxHP1 = 0;
		public int _maxHP2 = 0;
		public int _currentHP1 = 0;
		public int _currentHP2 = 0;

		[Space]
		public int MeleeAttackValue1;
		public int MeleeAttackValue2;
		public float MeleeAttack1Delay = 0;
		public float MeleeAttack2Delay = 0;
		[FormerlySerializedAs("MeleeAttackDuration1")] public float MeleeAttackCooldown1 = 0;
		[FormerlySerializedAs("MeleeAttackDuration2")] public float MeleeAttackCooldown2 = 0;
		public float MeleeAttackAnimationSpeed1 = 0;
		public float MeleeAttackAnimationSpeed2 = 0;
		
		[Space]
		public int RangeAttackValue1;
		public int RangeAttackValue2;
		public float RangePreAttackTime1 = 0;
		public float RangePreAttackTime2 = 0;
		public float RangeAttackAnimationSpeed1 = 0;
		public float RangeAttackAnimationSpeed2 = 0;
		public float RangeAttackFrequency = 0f;
		
		[Space]
		public int RangeEnergyValue1;
		public int RangeEnergyValue2;
		
		[Space]
		public float AttackDistance = 0;
		public Vector2 DamageForce = Vector2.zero;
		public int Coins = 0;
		public int DamageKnockbackResist = 0;

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

		public int GetEnergy(DamageType damageType)
		{
			switch (damageType)
			{
				case DamageType.Type1:
					return RangeEnergyValue2;
				case DamageType.Type2:
					return RangeEnergyValue1;
			}

			return 0;
		}
		
		public float GetMeleeAttackDuration(DamageType damageType)
		{
			switch (damageType)
			{
				case DamageType.Type1:
					return MeleeAttackCooldown1;
				case DamageType.Type2:
					return MeleeAttackCooldown2;
			}

			return 0;
		}

		public float GetMeleeAttackAnimationSpeed(DamageType damageType)
		{
			switch (damageType)
			{
				case DamageType.Type1:
					return MeleeAttackAnimationSpeed1;
				case DamageType.Type2:
					return MeleeAttackAnimationSpeed2;
			}

			return 0;
		}

		public bool IsDeath()
		{
			if (_currentHP1 <= 0 || _currentHP2 <= 0)
			{
				return true;
			}

			return false;
		}

		public float GetRangePreAttackTime(DamageType damageType)
		{
			switch (damageType)
			{
				case DamageType.Type1:
					return RangePreAttackTime1;
				case DamageType.Type2:
					return RangePreAttackTime2;
			}

			return 0;
		}

		public float GetRangeAttackSpeed(DamageType damageType)
		{
			switch (damageType)
			{
				case DamageType.Type1:
					return RangeAttackAnimationSpeed1;
				case DamageType.Type2:
					return RangeAttackAnimationSpeed2;
			}

			return 0;
		}
	}
}