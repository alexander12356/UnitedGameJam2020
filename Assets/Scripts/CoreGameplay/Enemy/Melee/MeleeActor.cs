using System;

using BR;
using BR.Actor;
using BR.Enemy;

using CommandPattern;

using UnityEngine;

public class MeleeActor : MonoBehaviour, IActor
{
    private MeleeData _data;
    private IAttackController _attackController;
    private IMovement _movement;
    [SerializeField] private Coin _coinPrefab = null;
    
    private void Awake()
    {
        _data = GetComponent<MeleeData>();
        _movement = GetComponent<IMovement>();
        _attackController = GetComponent<IAttackController>();
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
        _data.Damage(value, type);

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
        _attackController.Attack(damageType, _movement.Direction);
    }

    public void LookAt(MoveDirection direction)
    {
        _movement.LookAt(direction);
    }

    public void RangeAttack(DamageType damageType)
    {
    }

    public void GetEnergy(DamageType type)
    {
    }
}
