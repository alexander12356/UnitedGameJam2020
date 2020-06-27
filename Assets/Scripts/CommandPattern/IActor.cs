using BR;

namespace CommandPattern
{
	public interface IActor
	{
		void Move(float value);
		void Jump();
		void Damage(int value, DamageType type);
		void Death();
	}
}