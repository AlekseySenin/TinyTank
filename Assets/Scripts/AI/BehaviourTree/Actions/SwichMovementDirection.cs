using TheKiwiCoder;

public class SwichMovementDirection : ActionNode
{
    protected override void OnStart() {
        
    }

    protected override void OnStop() {
    }

    protected override State OnUpdate() {
        context.MoveFront = !context.MoveFront;
        return State.Success;
    }
}
