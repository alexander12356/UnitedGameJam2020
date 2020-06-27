using BR;
using BR.Actor;
using BR.Projectile;

using UnityEngine;

namespace Actor
{
	public class RangeAttackController : MonoBehaviour
	{
		private ActorData _actorData = null;
		private bool _canAttack = true;

		public Projectile ProjectilePrefab;

		[SerializeField] private Transform spawn = null;

		private void Awake()
		{
			_actorData = GetComponent<ActorData>();
		}

		public void Attack(DamageType damageType, MoveDirection direction, string targetTag)
		{
			if (!_canAttack)
			{
				return;
			}

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