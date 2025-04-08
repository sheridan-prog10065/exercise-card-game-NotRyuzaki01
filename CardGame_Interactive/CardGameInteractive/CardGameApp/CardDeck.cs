namespace CardGameApp;
/// <summary>
/// Defines the card deck as a list of cards.
/// </summary>
public class CardDeck
{
    /// <summary>
    /// The list of cards in the deck.
    /// </summary>
    private List<Card> _cardList;
    private const int MAX_SUIT_COUNT = 4;
    private const int MAX_CARD_VALUE = 13;
    private static Random s_randomizer;

    static CardDeck()
    {
        s_randomizer = new Random();
    }

    public CardDeck()
    {
        _cardList = new List<Card>();
        CreateCards();
    }

    public static Random Randomizer
    {
        get { return s_randomizer; }
    }

    public int CardCount
    {
        get { return _cardList.Count; }
    }

    private void CreateCards()
    {
        // for each suit in the deck 
        for(int iSuit = 1; iSuit <= MAX_SUIT_COUNT; iSuit++)
        {
            CardSuit suit = (CardSuit)iSuit;
            // for each card value
            for(byte value = 1; value <= MAX_CARD_VALUE; value++)
            {
                // create the card object with the given suit and value
                Card card = new Card(value, suit);
                
                // add the card to the deck
                _cardList.Add(card);
            }
        }
    }

    public void ShuffleCards()
    {
        // for each card in the deck 
        for(int iCard = 0; iCard < _cardList.Count; iCard++)
        {
            // choose random position in the deck
            int randPos = s_randomizer.Next(iCard, _cardList.Count);
            
            // replace current card with the card at the random position
            Card crtCard = _cardList[iCard];
            Card randCard = _cardList[randPos];
            _cardList[randPos] = crtCard;
            _cardList[iCard] = randCard;
        }
    }

    public bool GetPairOfCards(out Card cardOne, out Card cardTwo)
    {
        if (_cardList.Count >= 2)
        {
            int randPos = CardDeck.Randomizer.Next(0, _cardList.Count);
            int randPos2 = CardDeck.Randomizer.Next(0, _cardList.Count);

            cardOne = _cardList[randPos];
            _cardList.RemoveAt(randPos);
            
            cardTwo = _cardList[randPos2];
            _cardList.RemoveAt(randPos2);
            
            return true;
        }
        else
        {
            cardOne = null;
            cardTwo = null;
            return false;
        }
    }

    public void ExchangeCards(ref Card cardOne, ref Card cardTwo)
    {
        (cardOne, cardTwo) = (cardTwo, cardOne);
    }
}
