using System.Collections;
using System.Collections.Generic;

using BR;

using CommandPattern;

using TMPro;

using UnityEngine;

public class RangeAttackCommand : Command
{
    public DamageType damageType = DamageType.Type1;

    public override void Execute(IActor actor)
    {
        actor.RangeAttack(damageType);
    }

    public override void Undo(IActor actor)
    {
    }

    protected override void SetCommandType()
    {
    }
}
