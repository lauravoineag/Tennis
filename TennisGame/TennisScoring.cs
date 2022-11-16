namespace TennisGame;

public class TennisScoring
{
    private int _playerOnePoints;
    private int _playerTwoPoints;
    public bool IsDeuce { get; private set; }

    private bool AreWeAtDeuce()
    {
        //return _playerOnePoints >= 3 && _playerOnePoints == _playerTwoPoints;
        return _playerOnePoints >= 3 && _playerTwoPoints >= 3;
    }
    
    /*private class GameResult
    {
        public bool _haveAWinner;
        public string _winnerName;
    }*/
    
    /*private GameResult DoWeHaveAWinner()
    {
        GameResult _result = new GameResult();
        if (_playerOnePoints >= 4 && _playerOnePoints - _playerTwoPoints >= 2)
        {
            _result._haveAWinner = true;
            _result._winnerName = "Game Player One";
        }
        
        if (_playerTwoPoints >= 4 && _playerTwoPoints - _playerOnePoints >= 2)
        {
            _result._haveAWinner = true;
            _result._winnerName = "Game Player Two";
        }

        return _result;
    }*/
    
    private (bool haveAWinner, string winnerName) DoWeHaveAWinner() //tuple used in place of simple class
    {
        if (_playerOnePoints >= 4 && _playerOnePoints - _playerTwoPoints >= 2)
        {
            return (true, "Game Player One");
        }
        
        if (_playerTwoPoints >= 4 && _playerTwoPoints - _playerOnePoints >= 2)
        {
            return (true, "Game Player Two");
        }
        return default;
    }
    
    public string GetScores()
    {
        string score;
        //GameResult result = DoWeHaveAWinner();
        var result = DoWeHaveAWinner();
        if (result.haveAWinner)
        {
            return result.winnerName;
        }
        IsDeuce = AreWeAtDeuce();

        if (IsDeuce == true)
        {
            score = "deuce";

            if (_playerTwoPoints -_playerOnePoints == 1 )
            {
                score = "advantagePlayerTwo";
            }
        
            if ( _playerOnePoints -_playerTwoPoints == 1)
            {
                score= "advantagePlayerOne";
            }
        }
        else
        { 
            string playerOneScore = ConvertPointsToScore(_playerOnePoints);  
            string playerTwoScore = ConvertPointsToScore(_playerTwoPoints);
            
            score = $"{playerOneScore} {playerTwoScore}";

            if ( playerOneScore == playerTwoScore)
            {
                score = $"{playerOneScore} all";
            }
        }
        return score;
    }
    
    public void PlayerOneScoresPoint()
    {
        _playerOnePoints++;
    }
    public void PlayerTwoScoresPoint()
    {
        _playerTwoPoints++;
    }

    private string ConvertPointsToScore(int points)
    {
        switch (points)
        {
            case 0: return "love";
            case 1 : return "fifteen";
            case 2 : return "thirty";
            case 3 : return "forty";
            default: return "deuce";
        }
    }
}

