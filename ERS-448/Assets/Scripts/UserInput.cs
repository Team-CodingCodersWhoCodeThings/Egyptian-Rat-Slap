﻿using System.Collections;
using System.Collections.Generic;
using UnityEngine;

public class UserInput : MonoBehaviour
{
    private ERS ers;
    // Start is called before the first frame update
    void Start()
    {
        ers = FindObjectOfType<ERS>();
    }

    // Update is called once per frame
    void Update()
    {
        GetMouseClick();
    }

    void GetMouseClick()
    {
        if (Input.GetMouseButtonDown(0))
        {
            Vector3 mousePosition = Camera.main.ScreenToWorldPoint(new Vector3(Input.mousePosition.x, Input.mousePosition.y, -10));
            RaycastHit2D hit = Physics2D.Raycast(Camera.main.ScreenToWorldPoint(Input.mousePosition), Vector2.zero);
            if (hit)
            {
                //Check what was hit
                if (hit.collider.CompareTag("Deck"))
                {
                    //clicked deck
                    print("Deck");
                    clickedDeck();
                }
                if (hit.collider.CompareTag("Button"))
                {
                    //clicked button
                    print("Button");
                    clickedButton();
                }
            }
        }
    }
    
    void clickedDeck()
    {
        ers.dealCards();
    }

    void clickedButton()
    {
        
    }
}
