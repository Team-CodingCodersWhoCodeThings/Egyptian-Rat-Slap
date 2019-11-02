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

    // Start is called before the first frame update
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

    // Update is called once per frame
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
