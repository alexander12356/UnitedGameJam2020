﻿using System;

using Actor;

using BR;
using BR.Actor;
using BR.Enemy;

using CommandPattern;

using UnityEngine;

public class RangeActor : MonoBehaviour, IActor
{
    private MeleeData _data;
    private RangeAttackController _attackController;
    private IMovement _movement;
    [SerializeField] private Coin _coinPrefab = null;
    
    private void Awake()
    {
        _data = GetComponent<MeleeData>();
        _movement = GetComponent<IMovement>();
        _attackController = GetComponent<RangeAttackController>();
    }

    private void Start()
    {
        _data.ResetData();
    }

    public void Move(float value)
    {
        _movement.Move(value);
    }

    public void Jump()
    {
    }

    public void Damage(int value, DamageType type)
    {
        _data.Damage(value, DamageType.Type1);

        if (_movement.Direction == MoveDirection.Left)
        {
            AddForce(new Vector2(_data.DamageForce.x, _data.DamageForce.y));
        }

        if (_movement.Direction == MoveDirection.Right)
        {
            AddForce(new Vector2(-_data.DamageForce.x, _data.DamageForce.y));
        }
    }

    public void Death()
    {
        Instantiate(_coinPrefab, transform.position, Quaternion.identity);
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
    }

    public void LookAt(MoveDirection direction)
    {
        _movement.LookAt(direction);
    }

    public void RangeAttack(DamageType damageType)
    {
        _attackController.Attack(damageType, _movement.Direction, "Player");
    }
}