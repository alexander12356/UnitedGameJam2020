using UnityEngine;

using Vector2 = UnityEngine.Vector2;

namespace BR.Actor
{
	public enum MoveDirection
	{
		Right,
		Left
	}

	public class ActorMovement : MonoBehaviour, IMovement
	{
		private Rigidbody2D _rigidbody2d = null;
		private Vector2 _velocity = Vector2.zero;
		private bool _isJump = false;
		private bool _isGround = false;
		private bool _isForced = false;
		private Vector2 Force = Vector2.zero;
		private bool _isCooldown = false;
		private MoveDirection _moveDirection = MoveDirection.Left;

		[SerializeField] private float _speed = 0f;
		[SerializeField] private float _jumpForce = 0f;
		[SerializeField] private CircleCollider2D _checkGroundCollider2D = null;
		[SerializeField] private LayerMask _groundMask = -1;
		[SerializeField] private float _forcedCooldown = 0;

		public MoveDirection Direction => _moveDirection;

		private void Awake()
		{
			_rigidbody2d = GetComponentInChildren<Rigidbody2D>();
		}

		public void Move(float direction)
		{
			_velocity = new Vector2(direction * _speed, _rigidbody2d.velocity.y);

			if (_velocity.x > 0f)
			{
				_moveDirection = MoveDirection.Right;
			}

			if (_velocity.x < 0)
			{
				_moveDirection = MoveDirection.Left;
			}
		}

		public void Jump()
		{
			if (_isCooldown)
			{
				return;
			}

			_isJump = true;
		}

		public void AddForce(Vector2 force)
		{
			_isForced = true;
			Force = force;
			_isCooldown = true;
			_velocity = Vector2.zero;;
			Invoke(nameof(ResetCooldown), _forcedCooldown);
		}

		private void FixedUpdate()
		{
			_isGround = Physics2D.OverlapCircle(_checkGroundCollider2D.transform.position, _checkGroundCollider2D.radius, _groundMask);

			if (!_isCooldown)
			{
				_rigidbody2d.velocity = _velocity;
			}

			JumpPhysicCalculate();
			ForcePhysicCalculate();
		}

		private void ForcePhysicCalculate()
		{
			if (!_isForced)
			{
				return;
			}

			_isForced = false;

			_rigidbody2d.AddForce(Force, ForceMode2D.Force);
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

		private void ResetCooldown()
		{
			_isCooldown = false;
		}
	}
}