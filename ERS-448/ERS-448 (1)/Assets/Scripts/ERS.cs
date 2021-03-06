﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class ERS : MonoBehaviour
{
    public GameObject cardPrefab;
    public Sprite[] cardFronts;
    public static string[] suits = new string[] {"C", "D", "H", "S"};
    public static string[] values = new string[] {"A", "2", "3", "4", "5", "6", "7", "8", "9", "10", "J", "Q", "K"};
    public List<string> deck;

    // Start is called before the first frame update
    void Start()
    {
        startGame();
    }

    // Update is called once per frame
    void Update()
    {
        
    }

    public void startGame()
    {
        deck = GenerateDeck();//Generate a deck for play.
        shuffle(deck);
        //output to console to test it
        foreach (string card in deck)
        {
            print(card);
        }
    }

    public static List<string> GenerateDeck()
    {
        List<string> newDeck = new List<string>();//create list.
        foreach (string s in suits)//use nested loop to populate newDeck with all 52 cards in format suit and value, ex. "S2"
        {
            foreach (string v in values)
            {
                newDeck.Add(s + v);
            }
        }

        return newDeck;
    }

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
}
