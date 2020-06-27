using System;

using BR.Actor;

using CommandPattern;

using UnityEngine;

namespace BR
{
    public class PlayerActor : MonoBehaviour, IActor
    {
        private IMovement _movement = null;
        private PlayerData _playerData = null;

        private void Awake()
        {
            _movement = GetComponent<IMovement>();
            _playerData = GetComponent<PlayerData>();
        }

        private void Start()
        {
            _playerData.ResetData();
        }

        public void Move(float value)
        {
            _movement.Move(value);
        }

        public void Jump()
        {
            _movement.Jump();
        }

        public void Damage(int value, DamageType damageType)
        {
            _playerData.Damage(value, damageType);
        }

        public void Death()
        {
            Destroy(gameObject);
        }
    }
}
