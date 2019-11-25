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

    [ConsoleMethod( "test", "Runs test of game functions" )]
	public static void ConsoleTest()
	{
        ers = FindObjectOfType<ERS>();
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
	}
}
