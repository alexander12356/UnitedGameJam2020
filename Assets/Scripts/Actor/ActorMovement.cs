using UnityEngine;

namespace BR.Actor
{
	public class ActorMovement : MonoBehaviour, IMovement
	{
		private Rigidbody2D _rigidbody2d = null;
		private Vector2 _velocity = Vector2.zero;
		private bool _isJump = false;
		private bool _isGround = false;

		[SerializeField] private float _speed = 0f;
		[SerializeField] private float _jumpForce = 0f;
		[SerializeField] private CircleCollider2D _checkGroundCollider2D = null;
		[SerializeField] private LayerMask _groundMask = -1;
		
		private void Awake()
		{
			_rigidbody2d = GetComponentInChildren<Rigidbody2D>();
		}

		public void Move(float direction)
		{
			_velocity = new Vector2(direction * _speed, _rigidbody2d.velocity.y);
		}

		public void Jump()
		{
			_isJump = true;
		}

		private void FixedUpdate()
		{
			_isGround = Physics2D.OverlapCircle(_checkGroundCollider2D.transform.position, _checkGroundCollider2D.radius, _groundMask);
			_rigidbody2d.velocity = _velocity;

			JumpPhysicCalculate();
		}

		private void JumpPhysicCalculate()
		{
			if (!_isJump)
			{
				return;
			}

			_isJump = false;

			if (!_isGround)
			{
				return;
			}

			_rigidbody2d.velocity = new Vector2(_rigidbody2d.velocity.x, 0.0f);
			_rigidbody2d.AddForce(Vector2.up * _jumpForce, ForceMode2D.Force);
		}
	}
}