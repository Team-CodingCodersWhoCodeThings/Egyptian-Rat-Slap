/// File Name TestScript.cs.
/// Assignment EECS 448 Project 3.
/// Brief Tests code in console.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;
using IngameDebugConsole;

public class TestScript : MonoBehaviour
{
    private static ERS ers;

    void Start()
    {
        
    }

    /*!
     \pre test is enterred in console.
     \post tests code and outputs to console.
     \return none.
    */

    [ConsoleMethod( "test", "Runs test of game functions" )]
	public static void ConsoleTest()
	{
        ers = FindObjectOfType<ERS>();
        /// Outputs message if difficulty is not selected before testing.
        if(ers.difficultySelect)
        {
            print("Pick any difficulty before running a test");
            return;
        }
        /// Creates bool and runs through series of tests.
        bool test = true;
        for(int i = 0; i < 26; i++)
        {
            if(ers.AIDeck[i] != ers.deck[i * 2])
            {
                test = false;
            }
        }
        for(int i = 0; i < 26; i++)
        {
            if(ers.PlayerDeck[i] != ers.deck[(i * 2) + 1])
            {
                test = false;
            }
        }
        if(test)
        {
            print("Test 1: startGame evenly splits 52 cards between players: SUCCESS");
        }
        else
        {
            print("Test 1: startGame evenly splits 52 cards between players: FAILURE");
        }
        ers.PlayerDeck.Clear();
        ers.pile.Clear();
        ers.PlayerDeck.Add("D2");
        ers.PlayerDeck.Add("DQ");
        ers.PlayerDeck.Add("D3");
        ers.pile.Add("D4");
        ers.playCard(ers.PlayerDeck);
        ers.playerTurn = true;
        if(ers.pile[1] == "D3")
        {
            print("Test 2: play Cards puts top card from deck to top of pile: SUCCESS");
        }
        else
        {
            print("Test 2: play Cards puts top card from deck to top of pile: FAILURE");
        }
        ers.playCard(ers.PlayerDeck);
        ers.playerTurn = true;
        if((ers.countdown == 2) && ers.countdownState)
        {
            print("Test 3: play Cards correctly triggers countdown state: SUCCESS");
        }
        else
        {
            print("Test 3: play Cards correctly triggers countdown state: FAILURE");
        }
        ers.resetBoard();
        test = true;
        for(int i = 0; i < 26; i++)
        {
            if(ers.AIDeck[i] != ers.deck[i * 2])
            {
                test = false;
            }
        }
        for(int i = 0; i < 26; i++)
        {
            if(ers.PlayerDeck[i] != ers.deck[(i * 2) + 1])
            {
                test = false;
            }
        }
        if(test)
        {
            print("Test 4: resetBoard properly resets decks: SUCCESS");
        }
        else
        {
            print("Test 4: resetBoard properly resets decks: FAILURE");
        }
        test = true;
        for(int i = 0; i < ers.deck.Count; i++)
        {
            if(GameObject.Find(ers.deck[i]) != null)
            {
                test = false;
            }
        }
        if(test)
        {
            print("Test 5: updatePile deletes all old card objects before making new cards: SUCCESS");
        }
        else
        {
            print("Test 5: updatePile deletes all old card objects before making new cards: FAILURE");
        }
        string[] testArr = new string[] {"D4", "D5", "D6", "H6"};
        ers.pile.Add("D4");
        ers.pile.Add("D5");
        ers.pile.Add("D6");
        ers.updatePile();
        test = true;
        for(int i = 0; i < ers.pile.Count; i++)
        {
            if(GameObject.Find(ers.pile[i]) == null)
            {
                test = false;
            }
        }
        if(test)
        {
            print("Test 6: updatePile creates object for all cards in pile: SUCCESS");
        }
        else
        {
            print("Test 6: updatePile creates object for all cards in pile: FAILURE");
        }
        test = true;
        if(ers.isValidSlap())
        {
            test = false;
        }
        ers.pile.Add("H6");
        if(!ers.isValidSlap())
        {
            test = false;
        }
        if(test)
        {
            print("Test 7: isValidSlap correctly detects slap: SUCCESS");
        }
        else
        {
            print("Test 7: isValidSlap correctly detects slap: FAILURE");
        }
        test = true;
        ers.slap(ers.PlayerDeck);
        for(int i = 0; i < 4; i++)
        {
            if(ers.PlayerDeck[i] != testArr[i])
            {
                test = false;
            }
        }
        if((ers.pile.Count == 0) && test)
        {
            print("Test 8: slap empties pile and puts it on the bottom of the deck: SUCCESS");
        }
        else
        {
            print("Test 8: slap empties pile and puts it on the bottom of the deck: FAILURE");
        }
        ers.resetBoard();
	}
}
