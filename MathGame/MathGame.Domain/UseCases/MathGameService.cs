using MathGame.Core.Entities;
using MathGame.Core.Interfaces;

public class MathGameService : IGameService
{
    private static readonly Random Random = new();
    private MathQuestion _currentQuestion;

    public MathQuestion GenerateQuestion()
    {
        var operations = new[] { "+", "-", "*", "/" };
        var num1 = Random.Next(1, 11);
        var num2 = Random.Next(1, 11);
        var op = operations[Random.Next(operations.Length)];

        double correctAnswer = op switch
        {
            "+" => num1 + num2,
            "-" => num1 - num2,
            "*" => num1 * num2,
            "/" => Math.Round((double)num1 / num2, 2),
            _ => 0
        };

        double modifiedAnswer = correctAnswer + Random.Next(-3, 4);
        _currentQuestion = new MathQuestion
        {
            Expression = $"{num1} {op} {num2} = {modifiedAnswer}",
            Answer = correctAnswer //
        };

        return _currentQuestion;
    }

    public bool ValidateAnswer(double proposedAnswer, bool isYes)
    {
        bool isCorrect = Math.Abs(proposedAnswer - _currentQuestion.Answer) < 0.001;
        return isYes == isCorrect;
    }
}
