using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

public class CheckCollision : DecoratorNode
{
    protected override void OnStart() {
    }

    protected override void OnStop() {
    }

    protected override State OnUpdate() {


        if (!context.aiActor.IsColliding() && child.Update() == State.Running)
        {
            return State.Running;
        }
        else return State.Success;

    }
}
