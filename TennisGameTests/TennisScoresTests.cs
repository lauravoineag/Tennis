using NUnit.Framework;
using TennisGame;

namespace TennisGameTests;

public class Tests
{
    private TennisScoring _sut;

    [SetUp]
    public void Setup()
    {
        _sut = new TennisScoring();
    }

    [Test]
    public void when_new_game_then_score_is_love_all()
    {
        //arrange - set
        var expected = "love all";
        //act - test - call method 
        var actual = _sut.GetScores();
        //assert -check
        Assert.That(actual, Is.EqualTo(expected));
    }
    
    [Test]
    public void when_playerOne_gets_one_point_then_score_is_fifteen_love()
    {
        //arrange - set
        var expected = "fifteen love";
        _sut.PlayerOneScoresPoint();
        
        //act - test - call method 
        var actual = _sut.GetScores();
        //assert -check
        Assert.That(actual, Is.EqualTo(expected));
    }

    /*private void SetPointsForPlayer(int noOfPoints, bool isPlayerOne)
    {
        Action methodToCall = isPlayerOne ? () => _sut.PlayerOneScoresPoint() :() => _sut.PlayerTwoScoresPoint();
        for (int i = 0; i < noOfPoints; i++)
        {
            methodToCall();
        }
    }*/
    
    private void SetPointsForPlayer(int noOfPoints, Action methodToCall)
    {
        for (int i = 0; i < noOfPoints; i++)
        {
            methodToCall();
        }
    }
    private void SetPointsForBothPlayers(int playerOnePoints, int playerTwoPoints)
    {
        SetPointsForPlayer(playerOnePoints,()=>_sut.PlayerOneScoresPoint()); //playerOnePoints
        SetPointsForPlayer(playerTwoPoints,()=>_sut.PlayerTwoScoresPoint()); //playerTwoPoints
    }
    
    [Test]
    public void when_playerOne_gets_two_points_then_score_is_thirty_love()
    {
        //arrange - set
        var expected = "thirty love";
        SetPointsForBothPlayers(2,0);
        
        //act - test - call method 
        var actual = _sut.GetScores();
        //assert -check
        Assert.That(actual, Is.EqualTo(expected));
    }
    
    [Test]
    public void when_both_players_get_two_points_score_is_thirty_all()
    {
        //arrange - set
        var expected = "thirty all";
        SetPointsForBothPlayers(2,2);

        //act - test - call method 
        var actual = _sut.GetScores();
        //assert -check
        Assert.That(actual, Is.EqualTo(expected));
    }
    
    [Test]
    public void when_playerTwo_gets_one_point_then_score_is_thirty_fifteen()
    {
        //arrange - set
        var expected = "thirty fifteen";
        SetPointsForBothPlayers(2,1);
        
        //act - test - call method 
        var actual = _sut.GetScores();
        //assert -check
        Assert.That(actual, Is.EqualTo(expected));
    }
    
    [Test]
    public void when_playerTwo_gets_one_point_score_is_love_fifteen()
    {
        //arrange - set
        var expected = "love fifteen";
        _sut.PlayerTwoScoresPoint();
        
        //act - test - call method 
        var actual = _sut.GetScores();
        //assert -check
        Assert.That(actual, Is.EqualTo(expected));
    }
    
    [Test]
    public void when_both_players_get_three_points_score_is_deuce()
    {
        //arrange - set
        var expected = "deuce";
        SetPointsForBothPlayers(3,3);
        
        //act - test - call method 
        var actual = _sut.GetScores();
        //assert -check
        Assert.That(actual, Is.EqualTo(expected));
    }
    
    [Test]
    public void when_both_players_get_nine_points_score_is_deuce()
    {
        //arrange - set
        var expected = "deuce";
        SetPointsForBothPlayers(9,9);
        
        //act - test - call method 
        var actual = _sut.GetScores();
        //assert -check
        Assert.That(actual, Is.EqualTo(expected));
        Assert.That(_sut.IsDeuce,Is.True);
    }
    
    [Test]
    public void when_playerOne_gets_five_points_and_playerTwo_gets_three_points_score_is_gamePlayerOne()
    {
        //arrange - set
        var expected = "Game Player One";
        SetPointsForBothPlayers(5,3);
        
        //act - test - call method 
        var actual = _sut.GetScores();
        //assert -check
        Assert.That(actual, Is.EqualTo(expected));
    }
    
    [Test]
    public void when_playerTwo_gets_five_points_and_playerOne_gets_three_points_score_is_gamePlayerTwo()
    {
        //arrange - set
        var expected = "Game Player Two";
        SetPointsForBothPlayers(3,5);
        
        //act - test - call method 
        var actual = _sut.GetScores();
        //assert -check
        Assert.That(actual, Is.EqualTo(expected));
    }
    [Test]
    public void when_playerOne_gets_two_points_and_playerTwo_gets_four_points_score_is_gamePlayerTwo()
    {
        //arrange - set
        var expected = "Game Player Two";
        SetPointsForBothPlayers(1,4);
        
        //act - test - call method 
        var actual = _sut.GetScores();
        //assert -check
        Assert.That(actual, Is.EqualTo(expected));
    }
    
    [Test]
    public void when_playerOne_gets_four_points_and_playerTwo_gets_three_points_score_is_advantagePlayerOne()
    {
        //arrange - set
        var expected = "advantagePlayerOne";
        SetPointsForBothPlayers(4,3);
        
        //act - test - call method 
        var actual = _sut.GetScores();
        //assert -check
        Assert.That(actual, Is.EqualTo(expected));
        Assert.That(_sut.IsDeuce,Is.True);
    }
    
    [Test]
    public void when_playerOne_gets_three_points_and_playerTwo_gets_four_points_score_is_advantagePlayerOne()
    {
        //arrange - set
        var expected = "advantagePlayerTwo";
        SetPointsForBothPlayers(3,4);
        
        //act - test - call method 
        var actual = _sut.GetScores();
        //assert -check
        Assert.That(actual, Is.EqualTo(expected));
    }
    
    [Test]
    public void when_playerOne_wins_game_and_playerTwo_does_not_score_any_points()
    {
        //arrange - set
        var expected = "Game Player One";
        SetPointsForBothPlayers(4,0);
        
        //act - test - call method 
        var actual = _sut.GetScores();
        //assert -check
        Assert.That(actual, Is.EqualTo(expected));
    }
    
    [Test]
    public void when_playerTwo_wins_game_and_playerOne_does_not_score_any_points()
    {
        //arrange - set
        var expected = "Game Player Two";
        SetPointsForBothPlayers(0,4);
        
        //act - test - call method 
        var actual = _sut.GetScores();
        //assert -check
        Assert.That(actual, Is.EqualTo(expected));
    }
    
    
    
}