using CommandPattern;

namespace BR
{
	public enum DamageType
	{
		Type1,
		Type2
	}

	public class DamageCommand : Command
	{
		public int DamageValue = 0;
		public DamageType DamageType = DamageType.Type1;
		
		public override void Execute(IActor actor)
		{
			actor.Damage(DamageValue, DamageType);
		}

		public override void Undo(IActor actor)
		{
		}

		protected override void SetCommandType()
		{
		}
	}
}