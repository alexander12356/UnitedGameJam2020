using CommandPattern;

namespace BR
{
	public class EnergyCommand : Command
	{
		public DamageType damageType = 0;

		public override void Execute(IActor actor)
		{
			actor.GetEnergy(damageType);
		}

		public override void Undo(IActor actor)
		{
		}

		protected override void SetCommandType()
		{
		}
	}
}