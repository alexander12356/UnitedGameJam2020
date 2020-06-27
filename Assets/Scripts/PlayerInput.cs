using System;

using CommandPattern;

using UnityEngine;

namespace BR
{
    public class PlayerInput : MonoBehaviour
    {
        private IActor _actor = null;
        private ICommand _moveCommand = null;
        private ICommand _jumpCommand = null;
        
        private void Awake()
        {
            _actor = GetComponent<IActor>();
            _moveCommand = new MoveCommand();
            _jumpCommand = new JumpCommand();
        }

        private void Update()
        {
            _moveCommand.Execute(_actor);

            if (Input.GetKeyDown(KeyCode.Space))
            {
                _jumpCommand.Execute(_actor);
            }
        }
    }
}
