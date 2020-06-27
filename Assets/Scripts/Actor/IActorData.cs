namespace BR.Actor
{
	public interface IActorData
	{
		void Damage(int value, DamageType damageType);
		void ResetData();
	}
}