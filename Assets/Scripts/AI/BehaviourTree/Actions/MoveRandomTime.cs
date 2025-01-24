using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using TheKiwiCoder;

public class MoveRandomTime : MoveAction
{
    public Vector2 DurationBounds;
    private float duration;
    private float startTime;

    protected override void OnStart()
    {
        duration = Random.Range(DurationBounds.x, DurationBounds.y);
        startTime = Time.time;
    }

    protected override void OnStop() {
    }

    protected override State OnUpdate() {
        if (Time.time - startTime > duration)
        {
            return State.Success;
        }
        return MoveTank();
    }
}
