using System.Numerics;

using CommandPattern;

using UnityEngine;

using Vector2 = UnityEngine.Vector2;

namespace BR.Actor
{
	public class PlayerAttackController : MonoBehaviour, IAttackController
	{
		private ActorData _actorData = null;
		private bool _isAttacking = false;
		private DamageCommand _damageCommand = null;

		[SerializeField] private CircleCollider2D _attackCollider2D = null;
		[SerializeField] private LayerMask _targetMasks = -1;
		
		private void Awake()
		{
			_actorData = GetComponent<ActorData>();
			_damageCommand = new DamageCommand();
		}

		public void Attack(DamageType damageType)
		{
			_damageCommand.DamageType = damageType;
			_damageCommand.DamageValue = _actorData.AttackValue;
			Invoke(nameof(AttackDelay), _actorData.AttackDelay);
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
			var position = _attackCollider2D.transform.position;

			var hit = Physics2D.CircleCast(position, _attackCollider2D.radius, Vector2.right, _actorData.AttackDistance, _targetMasks);
			
			var start = new Vector2(position.x, position.y);
			var end = start + Vector2.right * _actorData.AttackDistance;
				
			Debug.DrawLine(start, end, Color.red, 1);

			if (hit.collider != null)
			{
				_damageCommand.Execute(hit.collider.GetComponent<IActor>());
			}
		}
	}
}