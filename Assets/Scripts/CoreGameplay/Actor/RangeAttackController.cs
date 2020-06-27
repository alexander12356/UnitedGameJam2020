﻿using BR;
using BR.Actor;
using BR.Projectile;

using CommandPattern;

using UnityEngine;

namespace Actor
{
	public class RangeAttackController : MonoBehaviour
	{
		private ActorData _actorData = null;
		private IActor _actor = null;
		private bool _canAttack = true;
		private EnergyCommand _energyCommand = null;

		public Projectile ProjectilePrefab;

		[SerializeField] private Transform spawn = null;

		private void Awake()
		{
			_actorData = GetComponent<ActorData>();
			_actor = GetComponent<IActor>();
			_energyCommand = new EnergyCommand();
		}

		public void Attack(DamageType damageType, MoveDirection direction, string targetTag)
		{
			if (!_canAttack)
			{
				return;
			}

			_energyCommand.DamageType = damageType == DamageType.Type1 ? DamageType.Type2 : DamageType.Type1;
			_energyCommand.Execute(_actor);

			_canAttack = false;
			Invoke(nameof(ResetCanAttack), _actorData.RangeAttackFrequency);
			
			var projectile = Instantiate(ProjectilePrefab, spawn.position, Quaternion.identity);
			projectile.MoveDirection = direction;
			projectile.DamageType = damageType;
			projectile.DamageValue = _actorData.GetRangeDamageValue(damageType);
			projectile.TargetTag = targetTag;
		}

		private void ResetCanAttack()
		{
			_canAttack = true;
		}
	}
}