namespace CardGameApp;
/// <summary>
/// Define the score of the game.
/// </summary>
public class Score
{
    /// <summary>
    /// The number of rounds won by the player of the game.
    /// </summary>
    private int _playerScore;

    /// <summary>
    /// The number of rounds won by the house.
    /// </summary>
    private int _houseScore;

    public int PlayerScore
    {
        get { return _playerScore; }
        set { _playerScore = value; }
    }

    public int HouseScore
    {
        get { return _houseScore; }
        set { _houseScore = value; }
    }
}