using BR;
using BR.Actor;
using BR.Enemy;

using CommandPattern;

using UnityEngine;

public class MeleeAI : MonoBehaviour
{
    private MeleeData _actorData = null;
    private IActor _actor = null;
    private AttackCommand _attackCommand = null;
    private LookCommand _lookCommand = null;
    private MoveCommand _moveCommand = null;

    private void Awake()
    {
        _actor = GetComponent<IActor>();
        _actorData = GetComponent<MeleeData>();
        _attackCommand = new AttackCommand {DamageType = _actorData.AttackType};
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
            
            _attackCommand.Execute(_actor);
        }
    }
}
