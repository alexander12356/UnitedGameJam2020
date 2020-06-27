using CommandPattern;

namespace BR
{
	public class EnergyCommand : Command
	{
		public DamageType DamageType = 0;

		public override void Execute(IActor actor)
		{
			actor.GetEnergy(DamageType);
		}

		public override void Undo(IActor actor)
		{
		}

		protected override void SetCommandType()
		{
		}
	}
}