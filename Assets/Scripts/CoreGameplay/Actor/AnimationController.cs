using UnityEngine;

public class AnimationController : MonoBehaviour
{
	public Animator _animationController;
	
	public void Move(bool isMoving)
	{
		_animationController.SetBool("Run", isMoving);
	}

	public void Attack()
	{
		_animationController.SetTrigger("Attack");
	}

	public void Hurt()
	{
		_animationController.SetTrigger("Hurt");
	}

	public void Jump(bool value)
	{
		_animationController.SetBool("Jump", value);
	}

	public void Death()
	{
		_animationController.SetTrigger("Death");
	}

	public void RangeAttack()
	{
		_animationController.SetTrigger("RangeAttack");
	}
}
