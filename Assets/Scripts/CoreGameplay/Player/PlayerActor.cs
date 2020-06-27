﻿using Actor;

using BR.Actor;

using CommandPattern;

using MetaGameplay;

using UnityEngine;

namespace BR
{
    public class PlayerActor : MonoBehaviour, IActor
    {
        public static PlayerActor Instance = null;
        
        private IMovement _movement = null;
        private ActorData _actorData = null;
        private IAttackController _attackController = null;
        private RangeAttackController _rangeAttackController = null;
        public ActorData Data => _actorData;

        private void Awake()
        {
            Instance = this;
            
            _movement = GetComponent<IMovement>();
            _actorData = GetComponent<ActorData>();
            _attackController = GetComponent<IAttackController>();
            _rangeAttackController = GetComponent<RangeAttackController>();
        }

        private void Start()
        {
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
            _actorData.Damage(value, damageType);
        }

        public void Death()
        {
            Destroy(gameObject);
        }

        public void AddForce(Vector2 force)
        {
            _movement.AddForce(force);
        }

        public Vector2 GetPosition()
        {
            return transform.position;
        }

        public void Attack(DamageType damageType)
        {
            _attackController.Attack(damageType, _movement.Direction);
        }

        public void LookAt(MoveDirection direction)
        {
        }

        public void RangeAttack(DamageType damageType)
        {
            _rangeAttackController.Attack(damageType, _movement.Direction, "Enemy");
        }

        public void SaveCurrentStats()
        {
            PlayerStats.Instance.CurrentHP1 = _actorData._currentHP1;
            PlayerStats.Instance.CurrentHP2 = _actorData._currentHP2;
            PlayerStats.Instance.MeleeAttackValue1 = _actorData.MeleeAttackValue1;
            PlayerStats.Instance.MeleeAttackValue2 = _actorData.MeleeAttackValue2;
            PlayerStats.Instance.RangeAttackValue1 = _actorData.RangeAttackValue1;
            PlayerStats.Instance.RangeAttackValue2 = _actorData.RangeAttackValue2;
            PlayerStats.Instance.Coins = _actorData.Coins;
        }
    }
}
