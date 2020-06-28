using System;

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
    [SerializeField] private GameObject _poofPrefab = null;
    [SerializeField] private AnimationController _animationController1;
    [SerializeField] private AnimationController _animationController2;
    
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
        _data.Damage(value, type);

        if (_movement.Direction == MoveDirection.Left)
        {
            AddForce(new Vector2(_data.DamageForce.x, _data.DamageForce.y));
        }

        if (_movement.Direction == MoveDirection.Right)
        {
            AddForce(new Vector2(-_data.DamageForce.x, _data.DamageForce.y));
        }
        
        switch (type)
        {
            case DamageType.Type1:
                _animationController1?.Hurt();
                break;
            case DamageType.Type2:
                _animationController2?.Hurt();
                break;
        }

        _attackController.CancelAttack();
    }

    public void Death()
    {
        Instantiate(_coinPrefab, transform.position, Quaternion.identity);
        var poof = Instantiate(_poofPrefab, transform.position, Quaternion.identity);
        Destroy(poof, 1f);
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

    public void GetEnergy(DamageType type)
    {
    }
}
