using CommandPattern;

namespace BR.Enemy
{
	public class MeleeData : ActorData
	{
		private IActor _actor;

		public float _canAttackDistance = 0f;
		public DamageType AttackType;
		public DamageType DefenseType;

		private void Awake()
		{
			_actor = GetComponent<IActor>();
		}

		public override void Damage(int value, DamageType damageType)
		{
			if (damageType != DefenseType)
			{
				return;
			}
			
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
	}
}