using System.Diagnostics;

namespace CardGameApp;
/// <summary>
/// Defines the card game that implements the game logic and holds the card deck.
/// </summary>
public class CardGame
{
    /// <summary>
    /// Represents the deck of cards the game is using.
    /// </summary>
    private CardDeck _cardDeck;
    
    /// <summary>
    /// The score of the game
    /// </summary>
    private Score _score;
    
    /// <summary>
    /// The last card played by the user.
    /// </summary>
    private Card _playerCard;
    
    /// <summary>
    /// The last card played by the house.
    /// </summary>
    private Card _houseCard;

    public Score Score
    {
        get { return _score; }
        set { _score = value; }
    }

    public Card PlayerCard
    {
        get { return _playerCard; }
    }

    public Card HouseCard
    {
        get { return _houseCard; }
    }

    public bool IsOver
    {
        get { return _cardDeck.CardCount < 2; }
    }

    public bool PlayerWins
    {
        get { return IsOver && _score.PlayerScore > _score.HouseScore; }
    }

    public bool HouseWins
    {
        get { return IsOver && _score.HouseScore > _score.PlayerScore; }
    }
    
    /// <summary>
    /// The constructor of the card game class.
    /// </summary>
    public CardGame()
    {
        _cardDeck = new CardDeck();
        _cardDeck.ShuffleCards();
        _score = new Score();
        _playerCard = null;
        _houseCard = null;
    }

    /// <summary>
    /// Plays the game.
    /// </summary>
    public void Play()
    {
        
    }

    /// <summary>
    /// Play a round of the game
    /// </summary>
    /// <returns>
    ///     +1: the user won the round
    ///     0: there was a tie
    ///     -1: the house won the round
    /// </returns>
    public sbyte PlayRound()
    {
        //determine the card ranks for the player and house cards
        byte cardRank = DetermineCardRank(_playerCard);
        byte houseRank = DetermineCardRank(_houseCard);
        
        //check which card has the higer rank to determine the winner
        if (cardRank > houseRank)
        {
            //the player won the round
            Score.PlayerScore += 1;
            return 1;
            
        }
        else if (houseRank > cardRank)
        {
            //the house won the round
            Score.HouseScore += 1;
            return -1;
        }
        else
        {
            //there was a tie
            return 0;
        }
    }

    public void DealCards()
    {
        // extract two card from the deck and assign them to the player and the house
        bool cardsDealt = _cardDeck.GetPairOfCards(out _playerCard, out _houseCard);
        Debug.Assert(cardsDealt, "Cards could not be dealt. Check the game is not over.");
    }

    public void SwitchCards()
    {
        _cardDeck.ExchangeCards(ref _playerCard, ref _houseCard);
    }

    private byte DetermineCardRank(Card card)
    {
        byte cardRank = (card.Value == 1) ? (byte)14 : card.Value;
        if (card.Value == 1)
        {
            return 14;
        }
        else
        {
            return card.Value;
        }
    }

    private void ShowRoundResult()
    {
        
    }

    private void ShowGameOver()
    {
        
    }
}