using CommandPattern;

namespace BR
{
	public class AttackCommand : Command
	{
		public DamageType DamageType = DamageType.Type1;
		
		public override void Execute(IActor actor)
		{
			actor.Attack(DamageType);
		}

		public override void Undo(IActor actor)
		{
		}

		protected override void SetCommandType()
		{
		}
	}
}