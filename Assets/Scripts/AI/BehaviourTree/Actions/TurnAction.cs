using UnityEngine;
using TheKiwiCoder;

public class TurnAction : ActionNode
{
    public TurnDirection TurnDirection;
    protected TurnDirection _selectedDirection;
    protected override void OnStart() {
        if (TurnDirection == TurnDirection.random)
        {
            _selectedDirection = Random.value < 0.5f ? TurnDirection.left : TurnDirection.right;
        }
        else
        {
            _selectedDirection = TurnDirection;
        }
    }

    protected override void OnStop() {
    }

    protected override State OnUpdate() {

        return TurnTank();
    }

    public State TurnTank()
    {
        switch (_selectedDirection)
        {
            case TurnDirection.left:
                context.aiActor.TankMover.TurnLeft();
                return State.Running;

            case TurnDirection.right:
                context.aiActor.TankMover.TurnRight();
                return State.Running;

            default:
                return State.Failure;
        }
    }
}

[System.Serializable]
public enum TurnDirection
{
    left,right,random
}
