﻿using BR;
using BR.Actor;

using CommandPattern;

using UnityEngine;

public class DoorActor : MonoBehaviour, IActor
{
    private IActorData _actorData = null;
    public GameObject _poofPrefab = null;
 
    private void Awake()
    {
        _actorData = GetComponent<IActorData>();
    }

    private void Start()
    {
        _actorData.ResetData();
    }

    public void Move(float value)
    {
    }

    public void Jump()
    {
    }

    public void Damage(int value, DamageType type)
    {
        _actorData.Damage(value, type);
    }

    public void Death()
    {
        var poof = Instantiate(_poofPrefab, transform.position, Quaternion.identity);
        Destroy(poof, 1f);
        Destroy(gameObject);
    }

    public void AddForce(Vector2 force)
    {
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
    }

    public void RangeAttack(DamageType damageType)
    {
    }

    public void GetEnergy(DamageType type)
    {
    }
}
