using CommandPattern;

using UnityEngine;

using Vector2 = UnityEngine.Vector2;

namespace BR.Actor
{
	public class PlayerAttackController : MonoBehaviour, IAttackController
	{
		private ActorData _actorData = null;
		private bool _isAttacking = false;
		private bool _isStartAttack = false;
		private DamageCommand _damageCommand = null;
		private MoveDirection _moveDirection = MoveDirection.Left;

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
			_damageCommand.DamageValue = _actorData.AttackValue1;
			Invoke(nameof(AttackDelay), _actorData.AttackDelay);
			_moveDirection = direction;
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
			_isStartAttack = false;
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
	}
}