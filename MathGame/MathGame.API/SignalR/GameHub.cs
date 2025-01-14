using MathGame.Core.Interfaces;
using Microsoft.AspNetCore.SignalR;

namespace MathGame.API.SignalR;

public class GameHub : Hub
{
    private readonly IGameService _gameService;

    public GameHub(IGameService gameService) => _gameService = gameService;

    public override async Task OnConnectedAsync()
    {
        var question = _gameService.GenerateQuestion();
        await Clients.Caller.SendAsync("NewQuestion", new
        {
            question.Expression,
            CorrectAnswer = question.Answer
        });
    }

    public async Task SubmitAnswer(string username, double correctAnswer, double proposedAnswer, bool isYes, bool isCorrect)
    {
        // Validate the answer
        var isCorrectAnswer = Math.Abs(proposedAnswer - correctAnswer) < 0.001;

        // Optionally, process any logic you want here

        var result = new
        {
            Username = username,
            IsCorrect = isCorrectAnswer,
            UserAnswer = isYes ? "Yes" : "No"
        };

        await Clients.All.SendAsync("ReceiveResult", result);

        var question = _gameService.GenerateQuestion();
        await Clients.All.SendAsync("NewQuestion", new
        {
            Expression = question.Expression,
            CorrectAnswer = question.Answer
        });
    }

}
