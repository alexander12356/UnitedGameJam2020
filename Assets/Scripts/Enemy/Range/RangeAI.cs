using System.Collections;
using System.Collections.Generic;

using BR;
using BR.Actor;
using BR.Enemy;

using CommandPattern;

using UnityEngine;

public class RangeAI : MonoBehaviour
{
    private MeleeData _actorData = null;
    private IActor _actor = null;
    private RangeAttackCommand _rangeAttackCommand = null;
    private LookCommand _lookCommand = null;
    private MoveCommand _moveCommand = null;

    private void Awake()
    {
        _actor = GetComponent<IActor>();
        _actorData = GetComponent<MeleeData>();
        _rangeAttackCommand = new RangeAttackCommand()
        {
            damageType = _actorData.AttackType
        };
        _lookCommand = new LookCommand();
        _moveCommand = new MoveCommand();
    }
    void Update()
    {
        var playerPos = PlayerActor.Instance.GetPosition();

        var position = transform.position;
        _moveCommand.Execute(_actor);
        if (Vector2.Distance(playerPos, position) <= _actorData._canAttackDistance)
        {
            if (playerPos.x > position.x)
            {
                _lookCommand.Direction = MoveDirection.Right;
                _lookCommand.Execute(_actor);
            }
            if (playerPos.x < position.x)
            {
                _lookCommand.Direction = MoveDirection.Left;
                _lookCommand.Execute(_actor);
            }
            
            _rangeAttackCommand.Execute(_actor);
        }
    }
}
