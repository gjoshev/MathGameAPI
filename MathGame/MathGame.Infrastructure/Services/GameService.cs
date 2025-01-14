using MathGame.Core.Entities;
using MathGame.Core.Interfaces;

namespace MathGame.Infrastructure.Services;

public class GameService : IGameService
{
    private readonly MathGameService _mathGameService = new();

    public MathQuestion GenerateQuestion()
    {
        return _mathGameService.GenerateQuestion();
    }

    public bool ValidateAnswer(double proposedAnswer, bool isYes)
    {
        return _mathGameService.ValidateAnswer(proposedAnswer, isYes);
    }
}
