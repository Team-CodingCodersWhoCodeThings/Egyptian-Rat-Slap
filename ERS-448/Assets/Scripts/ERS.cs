/// File Name ERS.cs.
/// Assignment EECS 448 Project 3.
/// Brief makes and displayes cards and handle gameplay.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ERS : MonoBehaviour
{
    public GameObject cardPrefab;
    public Sprite[] cardFronts;
    public Sprite[] cardWins;
    public Sprite[] turns;
    public int[] timings;
    public static string[] suits = new string[] {"C", "D", "H", "S"};
    public static string[] values = new string[] {"A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K"};
    public List<string> deck;
    public List<string> AIDeck;
    public List<string> PlayerDeck;
    public List<string> pile;
    public int pileIndex;
    public bool playerTurn;
    int slapTimer;
    int turnTimer;
    bool countdownState;
    int countdown;
    int countdownTimer;
    int reactionTimer;
    private SpriteRenderer winRenderer;
    public bool difficultySelect;

    /*!
     \pre file opened.
     \post game is started.
     \return none.
    */

    void Start()
    {
        timings = new int[] {50, 40};
        difficultySelect = true;
        reactionTimer = 1;
        slapTimer = 0;
        turnTimer = 0;
        startGame();
        winRenderer = GameObject.Find("Card Win").GetComponent<SpriteRenderer>();
    }

    /*!
     \pre game is ran.
     \post updates game.
     \return none.
    */

    void Update()
    {
        if(((AIDeck.Count == 0) || (PlayerDeck.Count == 0)) && (!isValidSlap()))
        {
            bool playerWin;
            if(PlayerDeck.Count == 0)
            {
                playerWin = false;
            }
            else
            {
                playerWin = true;
            }
            if(PlayerDeck.Count == 0)
            resetBoard();
            if(playerWin)
            {
                reactionTimer = 50;
                winRenderer.sprite = cardWins[5];
            }
            else
            {
                reactionTimer = 50;
                winRenderer.sprite = cardWins[4];
            }
        }
        if(playerTurn)
        {
            GameObject.Find("Player Turn").GetComponent<SpriteRenderer>().sprite = turns[0];
            GameObject.Find("AI Turn").GetComponent<SpriteRenderer>().sprite = null;
        }
        else
        {
            GameObject.Find("Player Turn").GetComponent<SpriteRenderer>().sprite = null;
            GameObject.Find("AI Turn").GetComponent<SpriteRenderer>().sprite = turns[1];
        }
        GameObject.Find("Player Deck Count").GetComponent<TextMesh>().text = PlayerDeck.Count.ToString();
        GameObject.Find("AI Deck Count").GetComponent<TextMesh>().text = AIDeck.Count.ToString();
    }

    void FixedUpdate()
    {
        if(!playerTurn)
        {
            turnTimer++;
            if(turnTimer > timings[0])
            {
                playCard(AIDeck);
            }
        }
        if(isValidSlap())
        {
            slapTimer++;
            if(slapTimer > timings[1])
            {
                slap(AIDeck);
            }
        }
        if((reactionTimer > 0) && (!difficultySelect))
        {
            reactionTimer--;
        }
        else
        {
            winRenderer.sprite = null;
        }
        if(countdownTimer > 0)
        {
            countdownTimer--;
        }
        if((countdown == 0) && (countdownTimer == 0) && countdownState) 
        {
                if(!playerTurn)
                {
                    for(int i = (pile.Count - 1); i >= 0; i--)
                    {
                        PlayerDeck.Insert(0, pile[i]);
                        pile.RemoveAt(i);
                    }
                    updatePile();
                    turnTimer = 0;
                    winRenderer.sprite = cardWins[1];
                    reactionTimer = 20;
                }
                else
                {
                    for(int i = (pile.Count - 1); i >= 0; i--)
                    {
                        AIDeck.Insert(0, pile[i]);
                        pile.RemoveAt(i);
                    }
                    updatePile();
                    winRenderer.sprite = cardWins[0];
                    reactionTimer = 20;
                }
                countdownState = false;
                playerTurn = !playerTurn;
                pileIndex = 0;
                slapTimer = 0;
        }
    }

    /*!
     \pre game is ran.
     \post creates and distributes deck.
     \return none.
    */

    public void startGame()
    {
       /// Generate a deck for play.
        deck = GenerateDeck();
        /// Shuffle cards.
        shuffle(deck);
        /// Divide the deck between AI and Player.
        for(int i = 0; i < 52; i++)
        {
            if(i%2 == 0)
            {
                AIDeck.Add(deck[i]);
            }
            else
            {
                PlayerDeck.Add(deck[i]);
            }
        }
        playerTurn = true;
    }

    /*!
     \pre game is ran.
     \post creates deck for all suits and values combos.
     \return none.
    */

    public static List<string> GenerateDeck()
    {
      /// create list.
        List<string> newDeck = new List<string>();
        /// use nested loop to populate newDeck with all 52 cards in format suit and value, ex. "S2".
        foreach (string s in suits)
        {
            foreach (string v in values)
            {
                newDeck.Add(s + v);
            }
        }

        return newDeck;
    }

    /*!
     \pre game is ran.
     \post randomizes deck.
     \param List<T> deck the deck.
     \return none.
    */

    void shuffle<T>(List<T> deck)
    {
        System.Random rng = new System.Random();
        int count = deck.Count;
        while(count > 1)
        {
            count--;
            int j = rng.Next(count + 1);
            T card = deck[j];
            deck[j] = deck[count];
            deck[count] = card;
        }
    }

    /*!
     \pre game is ran.
     \post adds cards and displays them in pile.
     \return none.
    */

    public void playCard(List<string> deck)
    {
        if((reactionTimer > 0) || (countdownState && (countdown == 0)))
        {
            return;
        }
        if((deck ==AIDeck) || (playerTurn))
        {
            if(deck.Count > 0)
            {
                pile.Add(deck[deck.Count - 1]);
                deck.RemoveAt(deck.Count - 1);
                updatePile();
            }
            turnTimer = 0;
            if(pile[pile.Count -1][1] == 'J')
            {
                playerTurn = !playerTurn;
                countdownState = true;
                countdown = 1;
            }
            else if(pile[pile.Count -1][1] == 'Q')
            {
                playerTurn = !playerTurn;
                countdownState = true;
                countdown = 2;
            }
            else if(pile[pile.Count -1][1] == 'K')
            {
                playerTurn = !playerTurn;
                countdownState = true;
                countdown = 3;
            }
            else if(pile[pile.Count -1][1] == 'A')
            {
                playerTurn = !playerTurn;
                countdownState = true;
                countdown = 4;
            }
            else if(countdownState)
            {
                countdown--;
                countdownTimer = (timings[0] + timings[1]) / 2;
                
            }
            else
            {
                playerTurn = !playerTurn;
            }
        }
    }

    /*!
     \pre game is ran.
     \post clears board and redistributes cards.
     \return none.
    */

    public void resetBoard()
    {
        pile.Clear();
        updatePile();
        AIDeck.Clear();
        PlayerDeck.Clear();
        shuffle(deck);//shuffle cards
        for(int i = 0; i < 52; i++)//divide the deck between AI and Player
        {
            if(i%2 == 0)
            {
                AIDeck.Add(deck[i]);
            }
            else
            {
                PlayerDeck.Add(deck[i]);
            }
        }
        playerTurn = true;
        slapTimer = 0;
        turnTimer = 0;
        reactionTimer = 0;
        countdownState = false;
        countdownTimer = 0;
    }

    void updatePile()
    {
        foreach (string card in deck)
        {
            DestroyImmediate(GameObject.Find(card));
        }
        float xoffset = 0.5f;
        float zoffset = 0.1f;
        for(int i = 0; i < pile.Count; i++)
        {
            GameObject newCard = Instantiate(cardPrefab, new Vector3(-10f  + (i * xoffset), 0, 0  - (i * zoffset)), Quaternion.identity);
            newCard.name = pile[i];
        }
    }

    bool isValidSlap()
    {
        if(pile.Count > 1)
        {
            if(pile[pile.Count - 1][1] == pile[pile.Count - 2][1])
            {
                return true;
            }
            else if(pile.Count > 2)
            {
                if(pile[pile.Count - 1][1] == pile[pile.Count - 3][1])
                {
                    return true;
                }
                else
                {
                    return false;
                }
            }
            else
            {
                return false;
            }
        }
        else
        {
            return false;
        }
    }

    public void slap(List<string> deck)
    {
        if(reactionTimer > 0)
        {
            return;
        }
        if(isValidSlap())
        {
            for(int i = (pile.Count - 1); i >= 0; i--)
            {
                deck.Insert(0, pile[i]);
                pile.RemoveAt(i);
            }
            updatePile();
            reactionTimer = 20;
            countdownState = false;
            countdown = 0;
            turnTimer = 0;
            if(deck == AIDeck)
            {
                winRenderer.sprite = cardWins[2];
                playerTurn = false;
            }
            else
            {
                winRenderer.sprite = cardWins[3];
                playerTurn = true;
            }
        }
        else if(deck.Count > 0)
        {
            pile.Insert(0, deck[deck.Count -1]);
            deck.RemoveAt(deck.Count -1);
            updatePile();
        }
        else
        {
            updatePile();
        }
        slapTimer = 0;
    }
}
