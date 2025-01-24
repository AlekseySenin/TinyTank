using Zenject;


public class ScoreDisplay : IntToTextDisplay
{
    [Inject] ScoreHolder _scoreHolder;
    public override void Enable()
    {
        _scoreHolder.OnScoreChange += Display;
    }
    public override void Disable()
    {
        _scoreHolder.OnScoreChange -= Display;
    }
    protected override void OnEnable()
    {
        Display(_scoreHolder.TotalScore);

        base.OnEnable();
    }
}

