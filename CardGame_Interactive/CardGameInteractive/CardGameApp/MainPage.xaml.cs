using System.Diagnostics;

namespace CardGameApp;

public partial class MainPage : ContentPage
{
    private static readonly ImageSource s_imageSourceCardBack;
    private CardGame _cardGame;
    public MainPage()
    {
        InitializeComponent();
        
        _cardGame = new CardGame();
    }

    static MainPage()
    {
        s_imageSourceCardBack = ImageSource.FromFile("playing_card_back.jpg");
    }

    private void OnDealCards(object sender, EventArgs e)
    {
        _imgPlayerCard.Source = s_imageSourceCardBack;
        _imgHouseCard.Source = s_imageSourceCardBack;
        _cardGame.DealCards();
        _txtGameBoard.Text = "You can play the round or swap cards with the house!";
        _btnDealCards.IsEnabled = false;
        _btnSwitchCards.IsEnabled = true;
        _btnPlayCards.IsEnabled = true;
    }
    
    private void OnSwitchCards(object sender, EventArgs e)
    {
        _cardGame.SwitchCards();
    }
    
    private void OnPlayCards(object sender, EventArgs e)
    {
        sbyte roundResult = _cardGame.PlayRound();
        ShowRoundResult(roundResult);
        _btnDealCards.IsEnabled = true;
        _btnSwitchCards.IsEnabled = false;
        _btnPlayCards.IsEnabled = false;

        if (_cardGame.IsOver)
        {
            ShowGameOver();
        }
    }

    private void ShowRoundResult(sbyte roundResult)
    {
        // update the scoreboard 
        _txtPlayerScore.Text = _cardGame.Score.PlayerScore.ToString();
        _txtHouseScore.Text = _cardGame.Score.HouseScore.ToString();
        
        // show the cards
        ShowCard(_imgPlayerCard, _cardGame.PlayerCard);
        ShowCard(_imgHouseCard, _cardGame.HouseCard);

        // display who won the round (player or house)
        switch (roundResult)
        {
            case 1:
                _txtGameBoard.Text = "Player Wins the Round!";
                break;
            case -1:
                _txtGameBoard.Text = "House Wins the Round!";
                break;
            case 0:
                _txtGameBoard.Text = "Draw!";
                break;
            default:
                Debug.Assert(false, "Unknown round result");
                break;
        }
    }

    private void ShowCard(Image imgControl, Card card)
    {
        // Determine the image source for image control based on the card values and suit
        char suitId = card.Suit.ToString()[0];
        string fileName = $"{suitId}{card.Value.ToString("00")}.png";

        // Set the image control
        imgControl.Source = ImageSource.FromFile(fileName);
    }

    private void ShowGameOver()
    {
        // Display who won the game
        if (_cardGame.PlayerWins)
        {
            _txtGameBoard.Text = "Player Wins the Game!";
        }
        else if (_cardGame.HouseWins)
        {
            _txtGameBoard.Text = "House Wins the Game!";
        }
        else
        {
            _txtGameBoard.Text = "Draw!";
        }
        
        // Disallow the dealing of the cards
        _btnDealCards.IsEnabled = false;
        _btnPlayCards.IsEnabled = false;
        _btnSwitchCards.IsEnabled = false;
        
        // Ask the user if they want to play again
        
    }
}