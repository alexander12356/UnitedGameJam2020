using BR;

using UnityEngine;

namespace CommandPattern
{
	public interface IActor
	{
		void Move(float value);
		void Jump();
		void Damage(int value, DamageType type);
		void Death();
		void AddForce(Vector2 force);
		Vector2 GetPosition();
	}
}