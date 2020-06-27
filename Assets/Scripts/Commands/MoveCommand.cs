using CommandPattern;

using UnityEngine;

namespace BR
{
	public class MoveCommand : Command
	{
		public override void Execute(IActor actor)
		{
			actor.Move(Input.GetAxis("Horizontal"));
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