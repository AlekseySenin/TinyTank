using Zenject;

public class HighScoreDisplay : IntToTextDisplay
{
    [Inject] ScoreHolder _scoreHolder;

    public override void Enable()
    {
        _scoreHolder.OnHighScoreChange += Display;
    }
    public override void Disable()
    {
        _scoreHolder.OnHighScoreChange -= Display;
    }
    protected override void OnEnable()
    {
        base.OnEnable();
        Display(_scoreHolder.MaxScore);
    }
}
