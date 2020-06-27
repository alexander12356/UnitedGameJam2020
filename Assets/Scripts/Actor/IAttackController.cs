using UnityEngine.UI;

namespace BR.Actor
{
	public interface IAttackController
	{
		void Attack(DamageType damageType, MoveDirection moveDirection);
	}
}