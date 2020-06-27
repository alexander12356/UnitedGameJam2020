using System.Collections;
using System.Collections.Generic;

using CommandPattern;

using UnityEngine;

public class JumpCommand : Command
{
    public override void Execute(IActor actor)
    {
        actor.Jump();
    }

    public override void Undo(IActor actor)
    {
    }

    protected override void SetCommandType()
    {
    }
}
