using BR;
using BR.Actor;
using BR.Projectile;

using UnityEngine;

namespace Actor
{
	public class RangeAttackController : MonoBehaviour
	{
		private ActorData _actorData = null;
		public Projectile ProjectilePrefab;

		[SerializeField] private Transform spawn = null;

		private void Awake()
		{
			_actorData = GetComponent<ActorData>();
		}

		public void Attack(DamageType damageType, MoveDirection direction, string targetTag)
		{
			var projectile = Instantiate(ProjectilePrefab, spawn.position, Quaternion.identity);
			projectile.MoveDirection = direction;
			projectile.DamageType = damageType;
			projectile.DamageValue = _actorData.RangeDamage;
			projectile.TargetTag = targetTag;
		}
	}
}