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
    public bool faceUp;

    /*!
     \pre game is ran.
     \post assigns card front sprites.
     \return none.
    */

    void Start()
    {
        faceUp = true;
        List<string> deck = ERS.GenerateDeck();
        ers = FindObjectOfType<ERS>();
        int pos = 0;
        foreach (string card in deck)
        {
            if(this.name == card)
            {
                cardFront = ers.cardFronts[pos];
                break;
            }
            pos++;
        }
        spriteRenderer = GetComponent<SpriteRenderer>();
    }

    /*!
     \pre game is ran.
     \post if card flipped, update sprite.
     \return none.
    */

    void Update()
    {
        if(faceUp)
        {
            spriteRenderer.sprite = cardFront;
        }
        else
        {
            spriteRenderer.sprite = cardBack;
        }
    }
}
