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
    public static string[] suits = new string[] {"C", "D", "H", "S"};
    public static string[] values = new string[] {"A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K"};
    public List<string> deck;
    public List<string> AIDeck;
    public List<string> PlayerDeck;
    public List<string> pile;
    public int pileIndex;

    /*!
     \pre file opened.
     \post game is started.
     \return none.
    */

    void Start()
    {
        startGame();
    }

    /*!
     \pre game is ran.
     \post updates game.
     \return none.
    */

    void Update()
    {

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
        /**output to console to test it
        foreach (string card in AIDeck)
        {
            print(card + " AI");
        }
        foreach (string card in PlayerDeck)
        {
            print(card + " Player");
        }
        print(AIDeck.Count + " " + PlayerDeck.Count);**/
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

    public void dealCards()
    {
        float xoffset = 0.4f;
        float zoffset = 0.1f;
        if((AIDeck.Count > 0) && (PlayerDeck.Count > 0))
        {
            pile.Add(PlayerDeck[PlayerDeck.Count - 1]);
            pile.Add(AIDeck[AIDeck.Count - 1]);
            AIDeck.RemoveAt(AIDeck.Count - 1);
            PlayerDeck.RemoveAt(PlayerDeck.Count - 1);
            while(pileIndex < pile.Count)
            {
                GameObject newCard = Instantiate(cardPrefab, new Vector3(-10.2f  + (pileIndex * xoffset), 0, 0  - (pileIndex * zoffset)), Quaternion.identity);
                newCard.name = pile[pileIndex];
                pileIndex++;
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
        foreach (string card in pile)
        {
            Destroy(GameObject.Find(card));
        }
        pile.Clear();
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
        pileIndex = 0;
        /** Test ouput for new decks
        foreach (string card in AIDeck)
        {
            print(card + " AI");
        }
        foreach (string card in PlayerDeck)
        {
            print(card + " Player");
        }
        print(AIDeck.Count + " " + PlayerDeck.Count);**/
    }
}
