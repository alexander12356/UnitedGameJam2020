using CommandPattern;

using UnityEngine;

namespace BR
{
    public class PlayerInput : MonoBehaviour
    {
        private IActor _actor = null;
        private MoveCommand _moveCommand = null;
        private ICommand _jumpCommand = null;
        private ICommand _attackCommand = null;
        private RangeAttackCommand _rangeAttackCommand = null;
        
        private void Awake()
        {
            _actor = GetComponent<IActor>();
            _moveCommand = new MoveCommand();
            _jumpCommand = new JumpCommand();
            _attackCommand = new AttackCommand();
            _rangeAttackCommand = new RangeAttackCommand();
        }

        private void Update()
        {
            _moveCommand.HorizontalAxis = Input.GetAxis("Horizontal");
            _moveCommand.Execute(_actor);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                _jumpCommand.Execute(_actor);
            }

            if (Input.GetMouseButtonDown(0))
            {
                ((AttackCommand) _attackCommand).DamageType = DamageType.Type1;
                _attackCommand.Execute(_actor);
            }

            if (Input.GetKey(KeyCode.LeftShift) && Input.GetMouseButtonDown(0))
            {
                _rangeAttackCommand.damageType = DamageType.Type1;
                _rangeAttackCommand.Execute(_actor);
            }
        }
    }
}
