/// File Name UpdateCard.cs.
/// Assignment EECS 448 Project 3.
/// Brief Assignes sprites.

using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UpdateCard : MonoBehaviour
{
    public Sprite cardFront;
    public Sprite cardBack;
    private SpriteRenderer spriteRenderer;
    private ERS ers;

    /*!
     \pre game is ran.
     \post assigns card front sprites.
     \return none.
    */

    void Start()
    {
        List<string> deck = ERS.GenerateDeck();
        ers = FindObjectOfType<ERS>();
        int pos = 0;
        /// Loop through all cards.
        foreach (string card in deck)
        {
            /// If name of object matches card front, use that card front sprite.
            if(this.name == card)
            {
                cardFront = ers.cardFronts[pos];
                break;
            }
            pos++;
        }
        spriteRenderer = GetComponent<SpriteRenderer>();
        spriteRenderer.sprite = cardFront;
    }

    void Update()
    {
        
    }
}
