using System;

using BR;
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
		private DamageType _damageType;
		private MoveDirection _moveDirection;
		private string _targetTag = null;

		public Projectile ProjectilePrefab1;
		public Projectile ProjectilePrefab2;

		[SerializeField] private Transform spawn = null;
		[SerializeField] private AnimationController _animationController1 = null;
		[SerializeField] private AnimationController _animationController2 = null;

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

			_damageType = damageType;
			_moveDirection = direction;
			_targetTag = targetTag;

			switch (damageType)
			{
				case DamageType.Type1:
					_animationController1?.SetFloat(_actorData.GetRangeAttackSpeed(damageType), "AttackSpeed");
					_animationController1?.RangeAttack();
					break;
				case DamageType.Type2:
					_animationController2?.SetFloat(_actorData.GetRangeAttackSpeed(damageType), "AttackSpeed");
					_animationController2?.RangeAttack();
					break;
			}
			Invoke(nameof(SpawnProjectile), _actorData.GetRangePreAttackTime(damageType));
		}

		private void SpawnProjectile()
		{
			var prefab = ProjectilePrefab1;

			if (_damageType == DamageType.Type2)
			{
				prefab = ProjectilePrefab2;
			}
			
			var projectile = Instantiate(prefab, spawn.position, Quaternion.identity);
			projectile.MoveDirection = _moveDirection;
			projectile.DamageType = _damageType;
			projectile.DamageValue = _actorData.GetRangeDamageValue(_damageType);
			projectile.TargetTag = _targetTag;

			Invoke(nameof(ResetCanAttack), _actorData.RangeAttackFrequency);
		}

		private void ResetCanAttack()
		{
			_canAttack = true;
		}

		public void CancelAttack()
		{
			CancelInvoke(nameof(SpawnProjectile));
			_canAttack = false;
			Invoke(nameof(ResetCanAttack), _actorData.RangeAttackFrequency);
		}
	}
}