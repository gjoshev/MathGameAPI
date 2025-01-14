
using MathGame.Core.Entities;

namespace MathGame.Core.Interfaces;

public interface IGameService
{
    MathQuestion GenerateQuestion();
    bool ValidateAnswer(double proposedAnswer, bool isYes);
}
