using UnityEngine;

namespace BR.Actor
{
	public interface IMovement
	{
		void Move(float direction);
		void Jump();
		void AddForce(Vector2 force);
		MoveDirection Direction { get; }
	}
}