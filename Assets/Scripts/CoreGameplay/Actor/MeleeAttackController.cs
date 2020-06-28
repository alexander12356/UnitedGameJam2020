using System;

using CommandPattern;

using UnityEngine;

using Vector2 = UnityEngine.Vector2;

namespace BR.Actor
{
	public class MeleeAttackController : MonoBehaviour, IAttackController
	{
		private ActorData _actorData = null;
		private bool _isAttacking = false;
		private bool _isStartAttack = false;
		private DamageCommand _damageCommand = null;
		private MoveDirection _moveDirection = MoveDirection.Left;
		
		[SerializeField] private AnimationController _animationController1 = null;
		[SerializeField] private AnimationController _animationController2 = null;
		[SerializeField] private CircleCollider2D _attackCollider2D = null;
		[SerializeField] private LayerMask _targetMasks = -1;
		
		private void Awake()
		{
			_actorData = GetComponent<ActorData>();
			_damageCommand = new DamageCommand();
		}

		public void Attack(DamageType damageType, MoveDirection direction)
		{
			if (_isStartAttack)
			{
				return;
			}

			_isStartAttack = true;
			
			_damageCommand.DamageType = damageType;
			_damageCommand.DamageValue = _actorData.GetMeleeDamageValue(damageType);
			_moveDirection = direction;

			switch (damageType)
			{
				case DamageType.Type1:
					Invoke(nameof(AttackDelay), _actorData.MeleeAttack1Delay);
					_animationController1?.SetFloat(_actorData.GetMeleeAttackAnimationSpeed(damageType), "AttackSpeed");
					_animationController1?.Attack();
					break;
				case DamageType.Type2:
					Invoke(nameof(AttackDelay), _actorData.MeleeAttack2Delay);
					_animationController2?.SetFloat(_actorData.GetMeleeAttackAnimationSpeed(damageType), "AttackSpeed");
					_animationController2?.Attack();
					break;
			}
		}

		public void CancelAttack()
		{
			CancelInvoke(nameof(AttackDelay));
			_isStartAttack = true;
			Invoke(nameof(CompleteAttack), _actorData.GetMeleeAttackDuration(_damageCommand.DamageType));
		}

		private void AttackDelay()
		{
			_isAttacking = true;
		}

		private void FixedUpdate()
		{
			if (!_isAttacking)
			{
				return;
			}

			_isAttacking = false;
			Invoke(nameof(CompleteAttack), _actorData.GetMeleeAttackDuration(_damageCommand.DamageType));
			var position = _attackCollider2D.transform.position;

			var direction = _moveDirection == MoveDirection.Left ? Vector2.left : Vector2.right;

			var hit = Physics2D.CircleCast(position, _attackCollider2D.radius, direction, _actorData.AttackDistance, _targetMasks);

			var start = new Vector2(position.x, position.y);
			var end = start + direction * _actorData.AttackDistance;
				
			Debug.DrawLine(start, end, Color.red, 1);

			if (hit.collider != null)
			{
				_damageCommand.Execute(hit.collider.GetComponent<IActor>());
				Debug.Log("Attack");
			}
		}

		private void CompleteAttack()
		{
			_isStartAttack = false;
		}
	}
}