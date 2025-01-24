using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

public class MoveAction : ActionNode
{
    protected override State OnUpdate() {
        
        return MoveTank();
    }
    protected State MoveTank()
    {
        if (context.MoveFront)
        {
            context.aiActor.TankMover.MoveFront();
        }
        else
        {
            context.aiActor.TankMover.MoveRare();
        }
        return State.Running;

    }
    protected override void OnStart()
    {

    }

    protected override void OnStop()
    {

    }
}
