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
        //output to console to test it
        foreach (string card in AIDeck)
        {
            print(card + " AI");
        }
        foreach (string card in PlayerDeck)
        {
            print(card + " Player");
        }
        print(AIDeck.Count + " " + PlayerDeck.Count);
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

    void dealCards()
    {
        float offset = 0;
        foreach (string card in AIDeck)//Create card objects for AI deck
        {
            GameObject newCard = Instantiate(cardPrefab, new Vector3(9, 4, 0 + offset), Quaternion.identity);
            newCard.name = card;
            offset = offset + 0.03f;
        }
        offset = 0;
        foreach (string card in PlayerDeck)//Create card objects for Player deck
        {
            GameObject newCard = Instantiate(cardPrefab, new Vector3(-9, -4, 0 + offset), Quaternion.identity);
            newCard.name = card;
            offset = offset + 0.03f;
        }
    }
}
