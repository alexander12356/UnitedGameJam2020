using BR.Actor;

using CommandPattern;

using UnityEngine;

namespace BR
{
    public class PlayerActor : MonoBehaviour, IActor
    {
        private IMovement _movement = null;
        
        private void Awake()
        {
            _movement = GetComponent<IMovement>();
        }

        public void Move(float value)
        {
            _movement.Move(value);
        }

        public void Jump()
        {
            _movement.Jump();
        }
    }
}
