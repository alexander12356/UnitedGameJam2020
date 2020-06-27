using System;

using BR.Actor;

using CommandPattern;

using UnityEngine;
using UnityEngine.UI;

namespace BR.Projectile
{
	public class Projectile : MonoBehaviour
	{
		private DamageCommand _damageCommand = null;

		[SerializeField] private float _speed = 0f;

		public MoveDirection MoveDirection = MoveDirection.Left;
		public string TargetTag = null;
		public int DamageValue = 0;
		public DamageType DamageType = DamageType.Type1;

		private void Awake()
		{
			_damageCommand = new DamageCommand();
		}

		public void Update()
		{
			var position = transform.position;
			position.x += MoveDirection == MoveDirection.Left ? -_speed * Time.deltaTime : _speed * Time.deltaTime;
			transform.position = position;
		}

		private void OnCollisionEnter2D(Collision2D other)
		{
			if (other.collider.CompareTag(TargetTag))
			{
				_damageCommand.DamageType = DamageType;
				_damageCommand.DamageValue = DamageValue;
				_damageCommand.Execute(other.gameObject.GetComponent<IActor>());
			}
			Destroy(gameObject);
		}
	}
}