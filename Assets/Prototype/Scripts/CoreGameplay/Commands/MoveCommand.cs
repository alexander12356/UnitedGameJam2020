using CommandPattern;

using UnityEngine;

namespace BR
{
	public class MoveCommand : Command
	{
		public float HorizontalAxis = 0f;
		public override void Execute(IActor actor)
		{
			actor.Move(HorizontalAxis);
		}

		public override void Undo(IActor actor)
		{
		}

		protected override void SetCommandType()
		{
			CommandType = CommandType.Move;
		}
	}
}