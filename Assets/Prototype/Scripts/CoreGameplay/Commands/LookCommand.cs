using BR.Actor;

using CommandPattern;

namespace BR
{
	public class LookCommand : Command
	{
		public MoveDirection Direction;
		
		public override void Execute(IActor actor)
		{
			actor.LookAt(Direction);
		}

		public override void Undo(IActor actor)
		{
		}

		protected override void SetCommandType()
		{
		}
	}
}